using NGramCategorisation;
using NGramCategorisation.NGramSets;
using System;
using System.Collections.Generic;
using Xunit;

namespace NGramXunitTests
{
    // Attibution: Most of the text used in this set of unit tests is taken
    // from Wikipedia in various languages.

    public class StringSetTests
    {
        StringSet hello1, hello2, hello3;
        StringSet englishTrainingParagraph,
                  frenchTrainingParagraph,
                  germanTrainingParagraph;

        public StringSetTests()
        {
            hello1 = new StringSet("Hello, World!");
            hello2 = new StringSet("World, Hello!");
            hello3 = new StringSet("Hello, World!");

            englishTrainingParagraph = new StringSet(@"The Commodore 64 was a
                        bestselling, 8-bit home computer from the 1980s. It was
                        created by Commodore International, and it entered the
                        market in 1982. Around 17 million units are believed to
                        have been sold. The Commodore 64 is often credited with
                        making personal computers popular amongst the masses.
                        This quality sparked comparisons with the Ford Model T.
                        The Commodore 64 was offered at relatively low prices,
                        and was available in malls, department stores, and toy
                        stores instead of solely in the shops of authorized
                        dealers.");

            frenchTrainingParagraph = new StringSet(@"Le Commodore 64 utilise un
                        microprocesseur 8 bits 6510 (un d�riv� proche du 6502
                        qui a la possibilit� de g�rer des banques de m�moires en
                        les amenant � la demande dans l'espace d'adressage du
                        processeur) et dispose de 64 kilooctets de m�moire vive.
                        Au Royaume-Uni, il a rivalis� en popularit� avec le ZX
                        Spectrum et a tir� b�n�fice d'un clavier de taille
                        normale et de puces graphiques et son plus avanc�es.");

            germanTrainingParagraph = new StringSet(@"Der Commodore 64 (kurz
                        C64, umgangssprachlich 64er oder �Brotkasten�) ist ein
                        8-Bit-Heimcomputer mit 64 KB Arbeitsspeicher. Seit
                        seiner Vorstellung im Januar 1982 auf der Winter
                        Consumer Electronics Show war der von Commodore gebaute
                        C64 Mitte bis Ende der 1980er Jahre sowohl als
                        Spielcomputer als auch zur Softwareentwicklung �u�erst
                        popul�r. Er gilt als der meistverkaufte Heimcomputer
                        weltweit[1] � Sch�tzungen der Verkaufszahlen bewegen
                        sich zwischen 12,5 Mio. und 30 Mio. Exemplaren. Der C64
                        erm�glichte mit seiner umfangreichen Hardwareausstattung
                        zu einem � nach einer teureren Einf�hrungsphase �
                        erschwinglichen Preis in den 1980er-Jahren erstmals
                        Zugang zu einem f�r die damalige Zeit leistungsstarken
                        Computer.");
        }

        [Fact]
        public void StringSet_IdentifyFrenchLanguage()
        {
            StringSet testLanguage = new StringSet(@"Le Sinclair ZX81 est un
                        ordinateur personnel 8 bits, con�u par Sinclair Research
                        et commercialis� par Timex Corporation en mars 1981. Le
                        bo�tier �tait noir avec un clavier � membrane ;
                        l'apparence distinctive de la machine venait du travail
                        du designer industriel Rick Dickinson");

            double distanceEnglish = testLanguage.GetDistance(englishTrainingParagraph);
            double distanceFrench = testLanguage.GetDistance(frenchTrainingParagraph);
            double distanceGerman = testLanguage.GetDistance(germanTrainingParagraph);

            Assert.True(distanceFrench < distanceEnglish);
            Assert.True(distanceFrench < distanceGerman);
        }

        [Fact]
        public void StringSet_IdentifyGermanLanguage()
        {
            StringSet testLanguage = new StringSet(@"Der Sinclair ZX81 ist ein
                        auf dem Z80-Mikroprozessor basierender Heimcomputer des
                        britischen Herstellers Sinclair Research Ltd. Die Zahl
                        in der Namensgebung bezieht sich auf das Jahr des
                        Markteintritts am 5. M�rz 1981.");

            double distanceEnglish = testLanguage.GetDistance(englishTrainingParagraph);
            double distanceFrench = testLanguage.GetDistance(frenchTrainingParagraph);
            double distanceGerman = testLanguage.GetDistance(germanTrainingParagraph);

            Assert.True(distanceGerman < distanceEnglish);
            Assert.True(distanceGerman < distanceFrench);
        }

        [Fact]
        public void StringSet_IdentifyEnglishLanguage()
        {
            StringSet testLanguage = new StringSet(@"The ZX81 is a home computer
                        produced by Sinclair Research and manufactured in
                        Scotland by Timex Corporation. It was launched in the
                        United Kingdom in March 1981 as the successor to
                        Sinclair's ZX80 and was designed to be a low-cost
                        introduction to home computing for the general public.
                        It was hugely successful, and more than 1.5 million
                        units were sold before it was discontinued.");

            double distanceEnglish = testLanguage.GetDistance(englishTrainingParagraph);
            double distanceFrench = testLanguage.GetDistance(frenchTrainingParagraph);
            double distanceGerman = testLanguage.GetDistance(germanTrainingParagraph);

            Assert.True(distanceEnglish < distanceFrench);
            Assert.True(distanceEnglish < distanceGerman);
        }

    }
}
