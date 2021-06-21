using System;

namespace SymmetricKeyEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = "";

            //MAIN LOOP
            while (true)
            {
                Console.WriteLine("Would you like to Encrypt[1] or decrypt[2] ?");
                int state = Convert.ToInt32(Console.ReadLine());

                //LOOP FOR ENCRYPTION / DECRYPTION STATE
                while (true)
                {
                    if (state == 1 || state == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR - Select [1] or [2]");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("\nWould you like to Encrypt[1] or decrypt[2] ?");
                        state = Convert.ToInt32(Console.ReadLine());
                    }
                }

                Console.WriteLine("\nEnter the encryption KEY (32Bytes Long): ");
                key = Console.ReadLine();

                if (key.Length == 32 && state == 1)
                {
                    beginEncryption(key);
                }
                else if (key.Length == 32 && state == 2)
                {
                    beginDecryption(key);
                }
                //LOOP FOR GETTING CORRECT KEY
                while (true)
                {
                    if (key.Length < 32 || key.Length > 32)
                    {

                        if (key.Length < 32)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR - that was not 32Bytes ## Too Short ! ##");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the encryption KEY (32Bytes Long): ");
                            key = Console.ReadLine();

                            if (key.Length == 32 && state == 1)
                            {
                                beginEncryption(key);
                            }
                            else if (key.Length == 32 && state == 2)
                            {
                                beginDecryption(key);
                            }


                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR - that was not 32Bytes ## Too Long ! ##");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the encryption KEY (32Bytes Long): ");
                            key = Console.ReadLine();

                            if (key.Length == 32 && state == 1)
                            {
                                beginEncryption(key);
                            }
                            else if (key.Length == 32 && state == 2)
                            {
                                beginDecryption(key);
                            }

                        }

                    }
                    if (key.Length == 32)
                    {
                        break;
                    }
                }
                Console.WriteLine("Would you like to continue? yes / no");
                String exit = "";
                exit = Console.ReadLine();
                if (exit.ToLower() == "no")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bye...");
                    Console.ForegroundColor = ConsoleColor.White;

                    //END OF MAIN LOOP
                    break;
                }
            }
            
           
        }
        static void beginEncryption(String key)
        {
            Console.WriteLine("Your key is: " + key);


            Console.WriteLine("Enter the text to encrypt: ");
            var plainText = Console.ReadLine();
            var encryptedText = AESOperation.EncryptString(key, plainText);
            Console.WriteLine($"Encrypted Text: {encryptedText}");
        }

        static void beginDecryption(String key)
        {
            Console.WriteLine("Your key is: " + key);

            Console.WriteLine("Enter the text to Decrypt: ");
            var encryptedText = Console.ReadLine();
            var decryptedText = AESOperation.DecryptString(key, encryptedText);
            Console.WriteLine($"Encrypted Text: {decryptedText}");

        }
    }
}
