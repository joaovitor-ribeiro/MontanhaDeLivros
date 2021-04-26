using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MontanhasDeLivros.Models;
using MontanhasDeLivros.Models.Enums;

namespace MontanhasDeLivros.Data
{
    public class SeedingService
    {
        private MontanhasDeLivrosContext _context;

        public SeedingService(MontanhasDeLivrosContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Book.Any() ||
                _context.SalesRecord.Any())
            {
                return; // DB has been seeded
            }

            Book b1 = new Book(1, "O sol é para todos", 31 , "Um dos maiores clássicos da literatura mundial", "Harper Lee", "José Olympio", 5);
            Book b2 = new Book(2, "Fahrenheit 451", 21, "Guy Montag é um bombeiro. Sua profissão é atear fogo nos livros. ", "Ray Bradbury", "Biblioteca Azul", 10);
            Book b3 = new Book(3, "1984", 13, "Publicado em 1949, o texto de Orwell nasceu destinado à polêmica.", "George Orwell", "Principis", 3);
            Book b4 = new Book(4, "A garota do lago", 8, "Summit Lake, uma pequena cidade entre montanhas, é esse tipo de lugar, bucólico e com encantadoras casas dispostas à beira de um longo trecho de água intocada", "Charlie Donlea", "Faro Editorial", 2);
            Book b5 = new Book(5, "Torto arado", 37, "as profundezas do sertão baiano, as irmãs Bibiana e Belonísia encontram uma velha e misteriosa faca na mala guardada sob a cama da avó", "Itamar Vieira Junior ", "Todavia", 9);
            Book b6 = new Book(6, "O conto da aia", 22, "O romance distópico O conto da aia, de Margaret Atwood, se passa num futuro muito próximo e tem como cenário uma república onde não existem mais jornais, revistas, livros nem filmes. As universidades foram extintas. ", "Margaret Atwood", "Rocco", 5);
            Book b7 = new Book(7, "A revolução dos bichos: Um conto de fadas", 15, "A revolução dos bichos é uma fábula sobre o poder. Narra a insurreição dos animais de uma granja contra seus donos", "George Orwell", "Companhia das Letras", 12);
            Book b8 = new Book(8, "Admirável mundo novo", 21, "Ele mostra uma sociedade inteiramente organizada segundo princípios científicos, na qual a mera menção das antiquadas palavras “pai” e “mãe” produzem repugnância", "Aldous Huxley", "Biblioteca Azul", 6);
            Book b9 = new Book(9, "Laranja Mecânica", 28, "Uma das mais brilhantes sátiras distópicas já escritas, Laranja Mecânica ganhou fama ao ser adaptado em uma obra magistral do cinema pelas mãos de Stanley Kubrick.", "Anthony Burgess", "Editora Aleph", 1);
            Book b10 = new Book(10, "O morro dos ventos uivantes", 12, "Único romance da escritora inglesa Emily Bronte, O morro dos ventos uivantes retrata uma trágica historia de amor e obsessão em que os personagens principais são a obstinada e geniosa Catherine Earnshaw e seu irmão adotivo, Heathcliff.", "Emily Brontë", "Principis", 7);
            
            

            //    Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            //    Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            //    Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            //    Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            //    Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            //    Seller s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2020, 03, 05), 31,1,b1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2020, 04, 15), 42,2,b2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2020, 01, 25), 13,1,b3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2020, 01, 12), 24,3,b4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2020, 02, 09), 37,1,b5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2020, 02, 18), 44,2,b6);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2020, 12, 02), 15,1,b7);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2020, 11, 01), 21,1,b8);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2020, 03, 30), 28,1,b9);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2020, 09, 05), 48,4,b10);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2020, 09, 15), 62,2,b1);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2021, 01, 25), 21,1,b2);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2021, 02, 05), 26,2,b3);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2021, 01, 02), 8,1,b4);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2021, 03, 06), 37,1,b5);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2021, 04, 16), 22,1,b6);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2021, 04, 21), 15,1,b7);
            SalesRecord r18 = new SalesRecord(18, new DateTime(2021, 02, 22), 21,1,b8);
            SalesRecord r19 = new SalesRecord(19, new DateTime(2021, 02, 18), 28,1,b9);
            SalesRecord r20 = new SalesRecord(20, new DateTime(2021, 01, 20), 12,1,b10);            

                _context.Book.AddRange(b1, b2, b3, b4, b5, b6, b7 ,b8, b9, b10);

            //    _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20
            );

             _context.SaveChanges();
        }
    }
}
