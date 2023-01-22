using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Programming
{
    public class Analyzer
    {
        public async Task<int> GetAmountSentenceAsync(string text)
        {
            return await Task<int>.Run(() =>
            {
                int Amount = 0;
                if (text != null)
                {
                    foreach (char a in text)
                    {
                        if ((int)a == 46)
                        {
                            Amount++;
                        }
                    }
                }
                return Amount;
            });
        }
        public async Task<int> GetAmountWordsAsync(string text)
        {
            return await Task<int>.Run(() =>
            {
                string[] AmountWord = text.Split(' ');
                return AmountWord.Length;
            });
        }
        public async Task<int> GetAmountSymbolsAsync(string text)
        {
            return await Task<int>.Run(() =>
            {
                return text.Length-1;
            });
        }

        public async Task<int> GetAmountInterrogativeAsync(string text)
        {
            return await Task<int>.Run(() =>
            {
                string[] AmountSentence = text.Split('?');
                if (AmountSentence.Length != null)
                {
                    return AmountSentence.Length - 1;
                }
                else
                {
                    return AmountSentence.Length;
                }
            });
        }

        public async Task<int> GetAmountExclamationAsync(string text)
        {
            return await Task<int>.Run(() =>
            {
                string[] AmountSentence = text.Split('!');
                if (AmountSentence.Length != null)
                {
                    return AmountSentence.Length - 1;
                }
                else
                {
                    return AmountSentence.Length;
                }
            });
        }
    }
}
