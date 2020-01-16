using System;
using System.Collections.Generic;
using System.Text;

namespace MosiacData
{
    public class SqlDataProvider : ISqlDataProvider

    {

        public string Fetch()

        {

            return "Hello from within the SqlDataProvider";

        }

    }



    public interface ISqlDataProvider

    {

        string Fetch();

    }
}
