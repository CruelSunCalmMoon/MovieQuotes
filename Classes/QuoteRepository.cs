using System;
using System.Collections.Generic;
using MovieQuotes.Interfaces;

namespace MovieQuotes
{
    public class QuoteRepository : IRepository<Quote>
    {
        private List<Quote> listQuote = new List<Quote>();
        public void Update(int id, Quote objecto)
        {
            listQuote[id] = objecto;
        }

        public void Exclude(int id)
        {
            listQuote[id].Exclude();
        }

        public void Insert(Quote objecto)
        {
            listQuote.Add(objecto);
        }

        public List<Quote> Lista()
        {
            return listQuote;
        }

        public int NextId()
        {
            return listQuote.Count;
        }

        public Quote BringBackId(int id)
        {
            return listQuote[id];
        }
    }
}