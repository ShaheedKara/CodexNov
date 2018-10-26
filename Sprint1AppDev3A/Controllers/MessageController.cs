using PagedList;
using Sprint1AppDev3A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sprint1AppDev3A.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index(int? Id, int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            MessageReplyViewModel vm = new MessageReplyViewModel();
            var count = dbContext.Messages.Count();

            decimal totalPages = count / (decimal)pageSize;
            ViewBag.TotalPages = Math.Ceiling(totalPages);
            vm.Messages = dbContext.Messages.OrderBy(x => x.DatePosted).ToPagedList(pageNumber, pageSize);
            ViewBag.MessagesInOnePage = vm.Messages;
            ViewBag.PageNumber = pageNumber;

            if (Id != null)
            {

                var replies = dbContext.Replies.Where(x => x.MessageId == Id.Value).OrderByDescending(x => x.ReplyDateTime).ToList();
                if (replies != null)
                {
                    foreach (var rep in replies)
                    {
                        MessageReplyViewModel.MessageReply reply = new MessageReplyViewModel.MessageReply();
                        reply.MessageId = rep.MessageId;
                        reply.Id = rep.Id;
                        reply.ReplyMessage = rep.ReplyMessage;
                        reply.ReplyDateTime = rep.ReplyDateTime;
                        reply.MessageDetails = dbContext.Messages.Where(x => x.Id == rep.MessageId).Select(s => s.MessageToPost).FirstOrDefault();
                        reply.ReplyFrom = rep.ReplyFrom;
                        vm.Replies.Add(reply);
                    }

                }
                else
                {
                    vm.Replies.Add(null);
                }


                ViewBag.MessageId = Id.Value;
            }

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }










        public ActionResult Create()
        {
            MessageReplyViewModel vm = new MessageReplyViewModel();

            return View(vm);
        }

        [HttpPost]
        [Authorize]
        public ActionResult PostMessage(MessageReplyViewModel vm)
        {
            var username = User.Identity.Name;
            string fullName = "";
            int msgid = 0;
            if (!string.IsNullOrEmpty(username))
            {
                var user = dbContext.Users.SingleOrDefault(u => u.UserName == username);
                fullName = string.Concat(new string[] { user.UserName, " ", user.UserName });
            }
            Message messagetoPost = new Message();
            if (vm.Message.Subject != string.Empty && vm.Message.MessageToPost != string.Empty)
            {
                messagetoPost.DatePosted = DateTime.Now;
                messagetoPost.Subject = vm.Message.Subject;
                messagetoPost.MessageToPost = vm.Message.MessageToPost;
                messagetoPost.From = fullName;

                dbContext.Messages.Add(messagetoPost);
                dbContext.SaveChanges();
                msgid = messagetoPost.Id;
            }

            return RedirectToAction("Index", "Message", new { Id = msgid });
        }
        [HttpPost]
        [Authorize]
        public ActionResult ReplyMessage(MessageReplyViewModel vm, int messageId)
        {
            var username = User.Identity.Name;
            string fullName = "";
            if (!string.IsNullOrEmpty(username))
            {
                var user = dbContext.Users.SingleOrDefault(u => u.UserName == username);
                fullName = string.Concat(new string[] { user.UserName, " ", user.UserName });
            }
            if (vm.Reply.ReplyMessage != null)
            {
                Reply _reply = new Reply();
                _reply.ReplyDateTime = DateTime.Now;
                _reply.MessageId = messageId;
                _reply.ReplyFrom = fullName;
                _reply.ReplyMessage = vm.Reply.ReplyMessage;
                dbContext.Replies.Add(_reply);
                dbContext.SaveChanges();
            }
            //reply to the message owner          - using email template

            //  var messageOwner = dbContext.Messages.Where(x => x.Id == messageId).Select(s => s.From).FirstOrDefault();
            //  var users = from user in dbContext.Users
            //        orderby user.FirstName
            //     select new
            //      {
            //        FullName = user.FirstName + " " + user.LastName,
            //       UserEmail = user.Email
            //  };
            //   var uemail = users.Where(x => x.FullName == messageOwner).Select(s => s.UserEmail).FirstOrDefault();
            //  SendGridMessage replyMessage = new SendGridMessage();
            // replyMessage.From = new MailAddress(username);
            //  replyMessage.Subject = "Reply for your message :" + dbContext.Messages.Where(i => i.Id == messageId).Select(s => s.Subject).FirstOrDefault();
            //  replyMessage.Text = vm.Reply.ReplyMessage;

            //   replyMessage.AddTo(uemail);

            // var credentials = new NetworkCredential("YOUR SENDGRID USERNAME", PASSWORD);
            // var transportweb = new Web(credentials);
            //  transportweb.DeliverAsync(replyMessage);
            return RedirectToAction("Index", "Message", new { Id = messageId });

        }
    }
}