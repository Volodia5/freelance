using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbConnectionLibrary.Tables;

namespace DbConnectionLibrary
{
    public class DbManager
    {
        public DbManager()
        {
            TableUser = new TableUser();
            TableOrder = new TableOrder();
            TableUsersOrder = new TableUsersOrder();
            TableCategories  =  new TableCategory();
        }


        public TableUser TableUser { get; private set; }
        public TableOrder TableOrder { get; private set; }
        public TableUsersOrder TableUsersOrder { get; private set; }
        public TableCategory TableCategories { get; private set; }
    }
}
