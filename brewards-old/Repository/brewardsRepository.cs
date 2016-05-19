using brewards.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Repository
{
    public class brewardsRepository
    {
        public brewardsContext context { get; set; }

        public brewardsRepository()
        {
            context = new brewardsContext();
        }
        public brewardsRepository(brewardsContext _context)
        {
            context = _context;
        }
    }
}