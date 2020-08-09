using System;
using CurrencyConverterForms;
using CurrencyConverterLibreria;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverterTests
{
    [TestClass]
    public class ConvertTest
    {
        [TestMethod]
        public void ConversionBreadth()
        {
            decimal result;
            decimal amount;
            BaseCurrency fromCur;
            BaseCurrency toCur;

            amount = 100.0M;
            fromCur = new USDCurrency();
            toCur = new USDCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "USD to USD should be no change");

            fromCur = new PENCurrency();
            toCur = new PENCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "PEN to PEN should be no change");

            fromCur = new EURCurrency();
            toCur = new EURCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            Assert.AreEqual(100.0M, result, "EUR to EUR should be no change");

            decimal expected;
            fromCur = new USDCurrency();
            toCur = new EURCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            expected = amount * 0.85M;
            Assert.AreEqual(expected, result, "USD to EUR is incorrect");

            fromCur = new PENCurrency();
            toCur = new EURCurrency();
            result = ConvertibleCurrency.CurrencyConvert(amount, fromCur, toCur);
            expected = amount / 3.53M * 0.85M;
            Assert.AreEqual(expected, result,"PEN to EUR is incorrect");
        }

        [TestMethod]
        public void ConvertTo()
        {
            ConvertibleCurrency currency;
            decimal result;
            decimal expected;

            currency = new ConvertibleCurrency(new USDCurrency(), 100.0M);
            result = currency.ConvertTo(new USDCurrency());
            Assert.AreEqual(100.0M, result, "USD to USD should be no change");

            currency = new ConvertibleCurrency(new EURCurrency(), 100.0M);
            result = currency.ConvertTo(new PENCurrency());
            expected = 100.0M / 0.85M * 3.53M;
            Assert.AreEqual(expected, result, "EUR to PEN incorrect result");
        }
    }
}
