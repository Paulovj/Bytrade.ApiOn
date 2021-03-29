using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BytradeApiOn.Functions
{
    public class LerAquivo
    {
        public void abrir(string caminho,int id)
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(caminho);

            // Display the file contents by using a foreach loop.
            foreach (string comando in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + comando);
                var command = new SqlCommad();
                command.gerarInsert(comando, id);

            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            //System.Console.ReadKey();
        }
    }
}
