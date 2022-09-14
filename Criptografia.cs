using System;
using System.IO;
using System.Security.Cryptography;

namespace CriptoFile
{
    internal class Criptografia
    {
        public static CspParameters cspp;
        public static RSACryptoServiceProvider rsa;

        private static string encrFolder;
        public static string EncrFolder
        {
            get
            {
                return encrFolder;
            }
            set
            {
                encrFolder = value;
                //Definine o caminho do arquivo
                PubKeyFile = EncrFolder + "rsaPublicKey.txt";
            }
        }

        public static string DecrFolder { get; set; }
        public static string ScrFolder { get; set; }

        //Arquivo de chave pública
        private static string PubKeyFile = EncrFolder + "rsaPublicKey.txt";

        //Chave contendo o nome para private/public key value pair
        public static string keyName;

        //Método para criar a chave pública
        public static string CreateASMKeys()
        {
            string result = "";

            //Armazena uma key pair na keu container
            if (string.IsNullOrEmpty(keyName))
            {
                result = "Chave pública não definida";
                return result;
            }

            cspp.KeyContainerName = keyName;
            rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;
            if (rsa.PublicOnly)
            {
                result = "Key: " + cspp.KeyContainerName + " - Somente Pública";
            }
            else
            {
                result = "Senha: " + cspp.KeyContainerName + " Criada!";
            }

            return result;
        }

        //Método para exportar a chave pública a um arquivo
        public static bool ExportPublicKey()
        {
            bool result = true;

            if (rsa == null)
            {
                return false;
            }

            if (!Directory.Exists(EncrFolder))
            {
                Directory.CreateDirectory(EncrFolder);
            }

            StreamWriter sw = new StreamWriter(PubKeyFile, false);

            try
            {
                sw.Write(rsa.ToXmlString(false));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                result = false;
            }
            finally
            {
                sw.Close();
            }

            return result;
        }

        //Método para importar a chave pública de um arquivo
        public static string ImportPublicKey()
        {
            string result = "";

            if (!File.Exists(PubKeyFile))
            {
                result = "Arquivo de chave pública não encontrado";
                return result;
            }

            if (string.IsNullOrEmpty(keyName))
            {
                result = "Chave pública não definida";
                return result;
            }

            StreamReader sr = new StreamReader(PubKeyFile);

            try
            {
                cspp.KeyContainerName = keyName;
                rsa = new RSACryptoServiceProvider(cspp);
                string keytxt = sr.ReadToEnd();
                rsa.FromXmlString(keytxt);
                rsa.PersistKeyInCsp = true;
                if (rsa.PublicOnly)
                {
                    result = "Key: " + cspp.KeyContainerName + " - Somente Pública";
                }
                else
                {
                    result = "Key: " + cspp.KeyContainerName + " - Key Pair Completa";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally
            {
                sr.Close();
            }

            return result;
        }

        //Método para criar a chave privada a partir de um valor definido
        public static string GetPrivateKey()
        {
            string result = "";

            if (string.IsNullOrEmpty(keyName))
            {
                result = "Chave privada não definida";
                return result;
            }

            cspp.KeyContainerName = keyName;
            rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;

            if (rsa.PublicOnly)
            {
                result = "Key: " + cspp.KeyContainerName + " - Somente Pública";
            }
            else
            {
                result = "Key: " + cspp.KeyContainerName + " - Key Pair Completa";
            }

            return result;
        }

        //Método para criptografar o arquivo 
        public static string EncryptFile(string inFile)
        {
            // Criar uma instância de Aes para criptografia simétrica dos dados.
            Aes aes = Aes.Create();
            ICryptoTransform transform = aes.CreateEncryptor();

            // Use RSACryptoServiceProvider para
            // criptografar a chave AES.
            // rsa é instanciado anteriormente: rsa = new RSACryptoServiceProvider(cspp);

            byte[] keyEncrypted = rsa.Encrypt(aes.Key, false);

            // Crie matrizes de bytes para conter
            // os valores de comprimento da chave e IV.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            int lKey = keyEncrypted.Length;
            LenK = BitConverter.GetBytes(lKey);
            int lIV = aes.IV.Length;
            LenIV = BitConverter.GetBytes(lIV);

            //  Escreva o seguinte no FileStream
            //  para o arquivo criptografado(outFs):
            //  - comprimento da chave
            //  - comprimento do IV
            //  - chave criptografada
            //  - o IV
            //  - o conteúdo da cifra criptografada

            int startFileName = inFile.LastIndexOf("\\") + 1;
            string outFile = EncrFolder + inFile.Substring(startFileName) + ".enc";


            try
            {
                using (FileStream outFs = new FileStream(outFile, FileMode.Create))
                {
                    outFs.Write(LenK, 0, 4);
                    outFs.Write(LenIV, 0, 4);
                    outFs.Write(keyEncrypted, 0, lKey);
                    outFs.Write(aes.IV, 0, lIV);

                    //Escreva o texto cifrado usando o CryptoStream para cryptografar
                    using (CryptoStream outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        //Criptografando um arquivo por vez, para economizar memória
                        int count = 0;
                        int offset = 0;

                        // blockSizeBytes pode ter qualquer tamanho arbitrário.
                        int blockSizeBytes = aes.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];
                        int bytesRead = 0;
                        using (FileStream inFs = new FileStream(inFile, FileMode.Open))
                        {

                            do
                            {
                                count = inFs.Read(data, 0, blockSizeBytes);
                                offset += count;
                                outStreamEncrypted.Write(data, 0, count);
                                bytesRead += blockSizeBytes;
                            } while (count > 0);

                            inFs.Close();
                        }

                        outStreamEncrypted.FlushFinalBlock();
                        outStreamEncrypted.Close();
                    }
                    outFs.Close();
                    File.Delete(inFile);//Deleta o arquivo original
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return $"Arquivo criptografado.\nOrigem: {inFile}\nDestino: {outFile}";
        }

        //Método para descriptografar o arquivo
        public static string DecryptFile(string inFile)
        {
            // Cria uma instância de AES para descriptografia simétrica dos dados.
            Aes aes = Aes.Create();

            // Cria vetores de bytes para obter o comprimento da chave criptografada e IV. 
            // Esses valores foram armazenados como 4 bytes cada no início do pacote criptografado.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            // Construir o nome do arquivo para o arquivo descriptografado.
            string outFile = DecrFolder + inFile.Substring(0, inFile.LastIndexOf("."));

            try
            {

                // Use objetos FileStream para ler o criptografado (inFs) e salve o arquivo descriptografado(outFs).

                using (FileStream inFs = new FileStream(EncrFolder + inFile, FileMode.Open))
                {
                    inFs.Seek(0, SeekOrigin.Begin);
                    inFs.Seek(0, SeekOrigin.Begin);
                    inFs.Read(LenK, 0, 3);
                    inFs.Seek(4, SeekOrigin.Begin);
                    inFs.Read(LenIV, 0, 3);

                    // Converta os comprimentos em valores inteiros.
                    int lenk = BitConverter.ToInt32(LenK, 0);
                    int lenIV = BitConverter.ToInt32(LenIV, 0);

                    // Determine a posição inicial do texto cifrado(startC) e seu comprimento(lenC)
                    int startC = lenk + lenIV + 8;
                    int lenC = (int)inFs.Length - startC;

                    // Cria vetores de bytes para a chave AES criptografada, o IV e o texto cifrado.
                    byte[] KeyEncrypted = new byte[lenk];
                    byte[] IV = new byte[lenIV];

                    // Extrai a chave e IV começando do índice 8 após os valores de comprimento.
                    inFs.Seek(8, SeekOrigin.Begin);
                    inFs.Read(KeyEncrypted, 0, lenk);
                    inFs.Seek(8 + lenk, SeekOrigin.Begin);
                    inFs.Read(IV, 0, lenIV);

                    if (!Directory.Exists(DecrFolder))
                    {
                        Directory.CreateDirectory(DecrFolder);
                    }

                    // Use RSACryptoServiceProvider para descriptografar a chave AES.
                    byte[] KeyDecrypted = rsa.Decrypt(KeyEncrypted, false);

                    // Descriptografa a chave
                    ICryptoTransform transform = aes.CreateDecryptor(KeyDecrypted, IV);

                    // Descriptografar o texto cifrado do FileSteam do arquivo(inFs) criptografado
                    // no FileStream para o arquivo descriptografado(outFs).
                    using (FileStream outFs = new FileStream(outFile, FileMode.Create))
                    {
                        int count = 0;
                        int offset = 0;

                        // blockSizeBytes pode ter qualquer tamanho arbitrário.
                        int blockSizeBytes = aes.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];

                        // Descriptografa um parte de cada vez para utilizar menos memória
                        // Comece no início do texto cifrado.
                        inFs.Seek(startC, SeekOrigin.Begin);
                        using (CryptoStream outStreamDecrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                        {
                            do
                            {
                                count = inFs.Read(data, 0, blockSizeBytes);
                                offset += count;
                                outStreamDecrypted.Write(data, 0, count);
                            } while (count > 0);

                            outStreamDecrypted.FlushFinalBlock();
                            outStreamDecrypted.Close();
                        }
                        outFs.Close();
                    }
                    inFs.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return $"Arquivo descriptografado. \nOrigem: {inFile}\nDestino: {outFile}";
        }
    }
    
}
