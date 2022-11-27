using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBalooWeb.CoucheAccesDB
{
    public class ExceptionAccesDB : Exception
    {
        public ExceptionAccesDB(string msgDetail) : base(msgDetail)
        {
        }
    }
}