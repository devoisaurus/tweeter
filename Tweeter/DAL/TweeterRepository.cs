using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
<<<<<<< HEAD
using Tweeter.Models;
=======
>>>>>>> upstream/master

namespace Tweeter.DAL
{
    public class TweeterRepository
    {
<<<<<<< HEAD
        private TweeterContext Context { get; set; }

=======
        public TweeterContext Context { get; set; }
>>>>>>> upstream/master
        public TweeterRepository(TweeterContext _context)
        {
            Context = _context;
        }

<<<<<<< HEAD
        public TweeterRepository()
        {
            Context = new TweeterContext();
        }
=======
        public TweeterRepository() {}

>>>>>>> upstream/master

    }
}