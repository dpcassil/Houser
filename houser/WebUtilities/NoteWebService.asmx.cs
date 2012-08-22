﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using houser.Business;

namespace houser.WebUtilities
{
    /// <summary>
    /// Summary description for NoteWebService
    /// </summary>
    [WebService(Namespace = "http://localhost:55560")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class NoteWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public void SaveAccountNote(string accountNumber, string note)
        {
            Note notes = new Note(accountNumber);
            notes.Notes = note;
            notes.Save();

        }

        [WebMethod]
        public string GetAccountNotes(string accountNumber)
        {
            Note notes = new Note(accountNumber);
            return notes.Notes;
        }
    }
}