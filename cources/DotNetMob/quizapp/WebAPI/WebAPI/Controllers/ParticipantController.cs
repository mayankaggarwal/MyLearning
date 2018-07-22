using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ParticipantController : ApiController
    {
        [HttpPost]
        [Route("api/Participant")]
        public Participant Insert(Participant model)
        {
            using(DBModels db = new DBModels())
            {
                db.Participants.Add(model);
                db.SaveChanges();
                return model;
            }
        }

        [HttpPut]
        [Route("api/Participant")]
        public void Update(Participant model)
        {
            using (DBModels db = new DBModels())
            {
                if(db.Participants.Any(x=>x.ParticipantID == model.ParticipantID))
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

    }
}
