using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweeter.Models;

namespace Tweeter.DAL
{
    public class TweeterRepository
    {
        private TweeterContext Context { get; set; }

        public TweeterRepository(TweeterContext _context)
        {
            Context = _context;
        }

        public TweeterRepository()
        {
            Context = new TweeterContext();
        }

    }
}