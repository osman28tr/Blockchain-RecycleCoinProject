#nullable enable
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RecycleCoinMvc.Models
{
    public class BlockchainSchema
    {
        public List<Block> chain { get; set; }
        public int difficulty { get; set; }
        public int miningReward { get; set; }
        public List<TransactionSchema> pendingTransactions { get; set; }
        public bool isChainValid { get; set; }
        
        private static BlockchainApi? _blockchainApi;

        public BlockchainSchema()
        {
            _blockchainApi = new BlockchainApi();
            
        }

        public BlockchainSchema GetBlockchain()
        {
            var j_res = _blockchainApi.Get("api/Blockchain/getBlockchain");
            this.chain = JsonConvert.DeserializeObject<List<Block>>(j_res["chain"].ToString());
            this.difficulty = j_res["difficulty"];
            this.miningReward = j_res["miningReward"];
            this.pendingTransactions = JsonConvert.DeserializeObject<List<TransactionSchema>>(j_res["pendingTransactions"].ToString());
            this.isChainValid = j_res["isChainValid"];
            return this;
        }

        public int GetBalanceOfAddress(string address)
        {
            int balanceOfAddress = Convert.ToInt32(_blockchainApi.Post("api/User/getBalanceOfAddress",
                new List<JProperty> { new("Address", address) }));
            return balanceOfAddress;
        }

        public void AddTransaction(string fromAddress, string toAddress, string amount)
        {
            var transactionContent = new List<JProperty> { new("fromAddress", fromAddress), new("toAddress", toAddress), new("amount", amount) };
            _blockchainApi.Post("api/Transaction/AddTransaction", transactionContent);
        }

        public void MinePendingTransactions(string miningRewardAddress)
        {
            var blockchainApi = new BlockchainApi();
            _blockchainApi.Post("api/Transaction/minerPendingTransactions",
                new List<JProperty> { new("minerRewardAddress", miningRewardAddress) });
        }

        public void SetDifficultyAndminingReward(int difficulty, int miningReward)
        {
            var blockchainApi = new BlockchainApi();
            this.difficulty = difficulty;
            this.miningReward = miningReward;
            blockchainApi.Post("api/Blockchain/setDifficultyAndminingReward", new List<JProperty> { new("difficulty", difficulty), new("reward", miningReward) });

        }

        public List<TransactionSchema> GetTransactionsOfAddress(string address)
        {
            GetBlockchain();
            List<TransactionSchema> transactions = new List<TransactionSchema>();
            foreach (var block in this.chain)
            {
                foreach (var transaction in block.transactions)
                {
                    if (address == transaction.fromAddress || address == transaction.toAddress)
                    {
                        transactions.Add(transaction);
                    }
                }
            }

            return transactions;

        }

    }


    public class Block
    {
        public string previousHash { get; set; }
        public string timestamp { get; set; }
        public string hash { get; set; }
        public string nonce { get; set; }
        public List<TransactionSchema> transactions { get; set; }
    }

    public class TransactionSchema
    {
        public string fromAddress { get; set; }
        public string toAddress { get; set; }
        public int amount { get; set; }
        public bool TransactionisValid { get; set; }
        public double timestamp { get; set; }
        public string signature { get; set; }
    }





}