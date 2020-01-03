using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using LibraryProjectBackend.Data;
using LibraryProjectBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryContext db;
        public LibraryController(LibraryContext context)
        {
            db = context;
        }
        // GET: api/library
        [HttpGet]
        public string Get()
        {
            return "Library'nin omurgasına hoşgeldiniz.";
        }
        // POST: api/library
        [HttpPost]
        public string LoginAndRegister([FromBody]loginandregister logreg)
        {
            if(logreg.token == "wJAVkz6f4StdbeREiQAo15WMlON8NV64vBEyn5SmRx6iFGUrcEd27SlRbOQRJbaP")
            {
                if(logreg.operation == "login")
                {
                    var result = db.AdminAccounts.Where(x => x.username == logreg.usernamedata && x.password == logreg.passworddata).FirstOrDefault();
                    if(result != null)
                    {
                        return "Ok";
                    }
                    else 
                    {
                        return "Error";
                    }
                }
                else if(logreg.operation == "register")
                {
                    AdminAccount newAC = new AdminAccount()
                   {
                        username = logreg.usernamedata,
                        password = logreg.passworddata,
                        tcId = logreg.tciddata
                    };
                    db.AdminAccounts.Add(newAC);
                    var control = db.SaveChanges();
                    if(control == 1)
                    {
                        return "Ok";
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else 
                {
                    return "404";
                }
            }
            else
            {
                return "Error";
            }
        }
        [HttpPost]
        [Route("bookoperation")]
        public string bookOperation([FromBody] bookoperation bop)
        {
            if(bop.token == "wJAVkz6f4StdbeREiQAo15WMlON8NV64vBEyn5SmRx6iFGUrcEd27SlRbOQRJbaP")
            {
                if(bop.operation == "viewBooks")
                {
                    var result = db.Books.Where(x => x.deleteState == 0).ToList();
                    if(result != null)
                    {
                        string json = JsonConvert.SerializeObject(result);
                        return json;
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else if(bop.operation == "addBook")
                {
                    Book newBook = new Book()
                    {
                        bookName = bop.booknamedata,
                        Author = bop.authordata,
                        bookPage = bop.pagedata,
                        deleteState = 0,
                        lentState = 0
                    };
                    db.Books.Add(newBook);
                    var control = db.SaveChanges();
                    if(control == 1)
                    {
                        return "Ok";
                    }
                    else 
                    {
                        return "Error";
                    }
                }
                else if(bop.operation == "deleteBook")
                {
                    var result = db.Books.Where(x => x.ID == bop.deletebookId).FirstOrDefault();
                    result.deleteState = 1;
                    var control = db.SaveChanges();
                    if(control == 1)
                    {
                        return "Ok";
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    return "Error";
                }
            }
            else
            {
                return "Error";
            }
        }
        [HttpPost]
        [Route("customeroperation")]
        public string customerOperation([FromBody] customeroperation cop)
        {
            if(cop.token == "wJAVkz6f4StdbeREiQAo15WMlON8NV64vBEyn5SmRx6iFGUrcEd27SlRbOQRJbaP")
            {
                if(cop.operation == "viewCustomers")
                {
                    var result = db.UserAccounts.Where(x => x.deleteState == 0).ToList();
                    if(result != null)
                    {
                        string json = JsonConvert.SerializeObject(result);
                        return json;
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else if(cop.operation == "addCustomer")
                {
                    UserAccount newUA = new UserAccount()
                    {
                        Fullname = cop.fullnamedata,
                        tcId = cop.tciddata,
                        deleteState = 0
                    };
                    db.UserAccounts.Add(newUA);
                    var control = db.SaveChanges();
                    if(control == 1)
                    {
                        return "Ok";
                    }
                    else 
                    {
                        return "Error";
                    }
                }
                else if(cop.operation == "deleteCustomer")
                {
                    var result = db.UserAccounts.Where(x => x.ID == cop.deletecustomerid).FirstOrDefault();
                    result.deleteState = 1;
                    var control = db.SaveChanges();
                    if(control == 1)
                    {
                        return "Ok";
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    return "Error";
                }
            }
            else
            {
                return "Error";
            }
        }
        [HttpPost]
        [Route("onlentbook")]
        public string onLentBook([FromBody] onlentbook lentb)
        {
            if(lentb.token == "wJAVkz6f4StdbeREiQAo15WMlON8NV64vBEyn5SmRx6iFGUrcEd27SlRbOQRJbaP")
            {
                int id = Convert.ToInt32(lentb.bookuserIddata);
                if(lentb.operation == "viewLentBooks")
                {
                    var result = db.BookUsers.Where(x => x.state == 1).ToList();
                    int resultCount = result.Count;
                    string[,] data = new string[resultCount,4];
                    if(result != null)
                    {
                        int j = 0;
                        foreach(var i in result)
                        {
                            var bookId = result[j].bookId;
                            var userID = result[j].customerId;
                            var resultTwo = db.Books.Where(x => x.ID == bookId).FirstOrDefault();
                            var resultThree = db.UserAccounts.Where(x => x.ID == userID).FirstOrDefault();
                            data[j,0] = result[j].ID.ToString();
                            data[j,1] = resultThree.Fullname;
                            data[j,2] = resultTwo.bookName;
                            data[j,3] = result[j].receiveBook.ToString();
                            j++;
                        }
                        string json = JsonConvert.SerializeObject(data);
                        return json;
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else if(lentb.operation == "takeItBack")
                {
                    var result = db.BookUsers.Where(x => x.ID == id).FirstOrDefault();
                    if(result != null)
                    {
                        result.state = 0;
                        int resultId = result.bookId;
                        var resultTwo = db.Books.Where(x => x.ID == resultId).FirstOrDefault();
                        resultTwo.lentState = 0;
                        int control = db.SaveChanges();
                        if(control != 0)
                        {
                            return "Ok";
                        }
                        else
                        {
                            return "Error";
                        }
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    return "Error";
                }
            }
            else
            {
                return "Error";
            }
        }
        [HttpPost]
        [Route("giveLentBook")]
        public string giveLentBook([FromBody] givelentbook glb)
        {
            if(glb.token == "wJAVkz6f4StdbeREiQAo15WMlON8NV64vBEyn5SmRx6iFGUrcEd27SlRbOQRJbaP")
            {
                if(glb.operation == "dataBook")
                {
                    var result = db.Books.Where(x => x.deleteState == 0 && x.lentState == 0).ToList();
                    if(result != null)
                    {
                        string json = JsonConvert.SerializeObject(result);
                        return json;
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else if(glb.operation == "dataCustomer")
                {
                    var result = db.UserAccounts.Where(x => x.deleteState == 0).ToList();
                    if(result != null)
                    {
                        string json= JsonConvert.SerializeObject(result);
                        return json;
                    }
                    else 
                    {
                        return "Error";
                    }
                }
                else if(glb.operation == "giveBook")
                {
                    CultureInfo myCultureInfo = new CultureInfo("tr-TR");
                    string dateString = glb.receiveBookdata;
                    DateTime receiveDate = DateTime.Parse(dateString, myCultureInfo);
                    BookUser newBU = new BookUser()
                    {
                        state = 1,
                        bookId = glb.bookIddata,
                        customerId = glb.customerIddata,
                        giveBook = DateTime.Now,
                        receiveBook = receiveDate
                    };
                    db.Add(newBU);
                    var result = db.Books.Where(x => x.ID == glb.bookIddata).FirstOrDefault();
                    result.lentState = 1;
                    var control = db.SaveChanges();
                    if(control != 0)
                    {
                        return "Ok";
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    return "Error;";
                }
            }
            else
            {
                return "Error";
            }
        }
    }
    public class loginandregister 
    {
        public string operation { get ; set; }
        public string token { get; set; } 
        public string usernamedata { get; set; }
        public string passworddata { get; set; }
        public string tciddata { get; set; }
    }
    public class bookoperation
    {
        public string operation { get ; set; }
        public string token { get ; set; }
        public int deletebookId { get ; set; }
        public string booknamedata { get ; set; }
        public string authordata { get ; set; }
        public string pagedata { get ; set; }
    }
    public class customeroperation 
    {
        public string operation { get ; set; }
        public string token { get ; set; }
        public int deletecustomerid { get ; set; }
        public string fullnamedata { get ; set; }
        public string tciddata { get ; set; }
    }
    public class onlentbook 
    {
        public string operation { get ; set; }
        public string token { get ; set; }
        public string bookuserIddata { get ; set; }
    }
    public class givelentbook 
    {
        public string operation { get ; set; }
        public string token { get ; set; }
        public int bookIddata { get ; set; }
        public int customerIddata { get ; set; }
        public string receiveBookdata { get ; set; }
    }
}
