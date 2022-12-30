using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RecycleCoinMvc.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RecycleCoin.Test
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void IsConnectionToBlockchainApi()
        {
            //Arange
            var blockchainApi = new BlockchainApi();
            //Act
            string defaultString = blockchainApi.Get("/").ToString();

            //Assert
            Assert.AreEqual(defaultString, "Hello World!");
        }

        [TestMethod]
        public void AfterChangingTheBlockchainSettingsIsItTheSameAsBeforeItChanged()
        {
            //Arange
            var blockchain = new BlockchainSchema().GetBlockchain();

            //Act
            var difficulty = blockchain.difficulty;
            var miningReward = blockchain.miningReward;

            blockchain.SetDifficultyAndminingReward(difficulty -1, miningReward + 10);

            var newDifficulty = blockchain.difficulty;
            var newMiningReward = blockchain.miningReward;

            //Assert
            Assert.AreNotEqual(difficulty, newDifficulty);
            Assert.AreNotEqual(miningReward, newMiningReward);


        }

        [TestMethod]
        public void GenerateKeyPairForNewUser()
        {
            //Arange
            var blockchainApi = new BlockchainApi();
            
            //Act
            var jRes = blockchainApi.Get("api/User/generateKeyPair");
            var publickey = jRes["publicKey"];
            var privateKey = jRes["privateKey"];
            
            //Assert
            Assert.IsNotNull(privateKey);
            Assert.IsNotNull(publickey);
        }

        [TestMethod]
        public void IsTransactionAddedToPendingTransactions()
        {
            //Arange
            var blockchain = new BlockchainSchema().GetBlockchain();
            //Act
            blockchain.AddTransaction("ffcad6fca220d9fb6d36829faa13b31f7f3d218b5b1a5f96a3029aed15eeacb3", "testToAddress", "555");
            var newBlockchain = new BlockchainSchema().GetBlockchain();
            
            var oldpendingTransactionsCount = blockchain.pendingTransactions.Count;
            var newpendingTransactionsCount = newBlockchain.pendingTransactions.Count;

            
            //Assert
            Assert.AreNotEqual(oldpendingTransactionsCount, newpendingTransactionsCount);
        }

        [TestMethod]
        public void IsBlockAddedToChainAfterMining()
        {
            //Arange
            var oldBlockchain = new BlockchainSchema().GetBlockchain();
            var oldChainCount = oldBlockchain.chain.Count;
            //Act

            oldBlockchain.MinePendingTransactions("testAddress");
            var newBlockchain = new BlockchainSchema().GetBlockchain();
            var newChainCount = newBlockchain.chain.Count;
            //Assert
            Assert.AreEqual(oldChainCount, newChainCount);
        }

    }
}
