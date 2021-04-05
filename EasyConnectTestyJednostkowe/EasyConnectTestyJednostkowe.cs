using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasyConnect;
using EasyConnectTestyJednostkowe;
using System;

namespace EasyConnectTestyJednostkowe
{
    [TestClass]
    public class EasyConnectTestyJednostkowe
    {
        [TestMethod]
        public void TestOdpowiedniejDlugœciNumeruTelefonu()
        {
            //przygotowanie
            string ContactNo = "123456789";
            long ContactNoMax = 9;

            //dzia³anie
            if (long.Parse(ContactNo) == ContactNoMax)
            { 
                //Numer telefonu jest odpowiedniej d³ugoœci
            }

            //weryfikacja
            Assert.AreEqual(ContactNo.Length, ContactNoMax);
        }

        [TestMethod]
        public void TestZbytKrotkiegoNumeruTelefonu()
        {
            //przygotowanie
            string ContactNo = "8437";
            long ContactNoMax = 9;

            //dzia³anie
            if (long.Parse(ContactNo) == ContactNoMax)
            {
                //Numer telefonu jest zbyt krotki
            }

            //weryfikacja
            Assert.AreEqual(ContactNo.Length, ContactNoMax);
        }

        [TestMethod]
        public void TestZbytDlugiegooNumeruTelefonu()
        {
            //przygotowanie
            string ContactNo = "84374432312";
            long ContactNoMax = 9;

            //dzia³anie
            if (long.Parse(ContactNo) == ContactNoMax)
            {
                //Numer telefonu jest zbyt d³ugi
            }

            //weryfikacja
            Assert.AreEqual(ContactNo.Length, ContactNoMax);
        }

        [TestMethod]
        public void TestCzyszczeniaPol()
        {
           
            string Id = "1";
            string Imie = "Krystian";
            string Nazwisko = "Olszewski";
            string NumerTelefonu = "694540282";
            string Adres = "Chwalowice 221";
            string Plec = "Male";
            string CzystePole = "";

            void Clear()
            {
                Id = "";
                Imie = "";
                Nazwisko = "";
                NumerTelefonu = "";
                Adres = "";
                Plec = "";
            }

            Clear();

            Assert.AreEqual(Id, CzystePole);
            Assert.AreEqual(Imie, CzystePole);
            Assert.AreEqual(Nazwisko, CzystePole);
            Assert.AreEqual(NumerTelefonu, CzystePole);
            Assert.AreEqual(Adres, CzystePole);
        }

    }
}
