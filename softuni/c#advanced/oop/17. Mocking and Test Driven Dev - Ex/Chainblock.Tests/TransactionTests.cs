using Chainblock.Contracts;
using Chainblock.Enums;
using Chainblock.Exceptions;
using Chainblock.Models;
using NUnit.Framework;
using System;
using System.Transactions;
using Transaction = Chainblock.Models.Transaction;
using TransactionStatus = Chainblock.Enums.TransactionStatus;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void ConstructorShouldInitializeTransactionProperly()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Goshho", 1000);
            Assert.IsNotNull(transaction);
        }
        [Test]
        public void ConstructorShouldInitializeIdProperly()
        {
            int expectedId = 1;
            ITransaction transaction = new Transaction(expectedId, TransactionStatus.Successfull, "Pesho", "Gosho", 1000);
            Assert.That(transaction.Id, Is.EqualTo(expectedId));
        }
        [Test]
        public void ConstructorShouldInitializeStatusProperly()
        {
            TransactionStatus expectedStatus = TransactionStatus.Unauthorised;
            ITransaction transaction = new Transaction(1, expectedStatus, "Pesho", "Gosho", 1000);
            Assert.That(transaction.Status, Is.EqualTo(expectedStatus));
        }
        [Test]
        public void ConstructorShouldInitializeSenderProperly()
        {
            string expectedSender = "Pesho";
            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, expectedSender, "Gosho", 1000);
            Assert.That(transaction.From, Is.EqualTo(expectedSender));
        }
        [Test]
        public void ConstructorShouldInitializeReceiverProperly()
        {
            string expectedReceiver = "Gosho";
            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", expectedReceiver, 1000);
            Assert.That(transaction.To, Is.EqualTo(expectedReceiver));
        }
        [Test]
        public void ConstructorShouldInitializeAmountProperly()
        {
            decimal expectedAmont = 1000;
            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", expectedAmont);
            Assert.That(transaction.Amount, Is.EqualTo(expectedAmont));
        }

        [TestCase(-100)]
        [TestCase(-1)]
        [TestCase(0)]
        public void IdSetterShouldThrowExceptionWithZeroOrNegativeId(int id)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Transaction(id, TransactionStatus.Successfull, "Pesho", "Gosho", 1000));
            Assert.That(exception.Message, Is.EqualTo(TransactionExceptionMessages.IdNotPositiveNumber));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void SenderSetterShouldThrowExceptionWithNullOrWhiteSpaceString(string from)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Transaction(1, TransactionStatus.Successfull, from, "Gosho", 1000));
            Assert.That(exception.Message, Is.EqualTo(TransactionExceptionMessages.SenderNullOrWhiteSpace));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void ReceiverSetterShouldThrowExceptionWithNullOrWhiteSpaceString(string to)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Transaction(1, TransactionStatus.Successfull, "Pesho", to, 1000));

            Assert.That(exception.Message, Is.EqualTo(TransactionExceptionMessages.ReceiverNullOrWhiteSpace));
        }

        [TestCase(-500)]
        [TestCase(-0.0000000001)]
        [TestCase(0)]
        public void AmountSetterShouldThrowExceptionWithZeroOrNegativeAmount(decimal amount)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", amount));

            Assert.That(exception.Message, Is.EqualTo(TransactionExceptionMessages.AmountNotPositiveNumber));
        }
    }
}