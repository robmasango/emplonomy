using System;

namespace Emplonomy.Model
{

        public class Error : IEntityBase
        {
            public int ID { get; set; }
            public string Message { get; set; }
            public string StackTrace { get; set; }
            public DateTime DateCreated { get; set; }
            public bool isDeleted { get; set; }
    }
    }
