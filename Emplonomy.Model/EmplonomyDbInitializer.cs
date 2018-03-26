using Bogus;
using System;
using System.Linq;

namespace Emplonomy.Model
{
    public class EmplonomyDbInitializer
    {

        private static EmplonomyContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (EmplonomyContext)serviceProvider.GetService(typeof(EmplonomyContext));

            InitializeEmplonomy();
        }

        private static void InitializeEmplonomy()
        {
            //-------------------------------------- Admin Start --------------------------------------------------------------------

            //Add Address Type
            if (!context.AddressTypes.Any())
            {
                AddressType addr1 = new AddressType() { AddressTypeDesc = "Home", isDeleted = false };
                AddressType addr2 = new AddressType() { AddressTypeDesc = "Work", isDeleted = false };
                AddressType addr3 = new AddressType() { AddressTypeDesc = "Other", isDeleted = false };

                context.AddressTypes.Add(addr1);
                context.AddressTypes.Add(addr2);
                context.AddressTypes.Add(addr3);

                context.SaveChanges();
            }

            //Add Departments


            // SEND ERROR

            if (!context.Errors.Any())
            {
                Error err1 = new Error() { Message = "error 1", StackTrace = "sample stack trace", DateCreated = DateTime.Now,  isDeleted = false };
                Error err2 = new Error() { Message = "error 2", StackTrace = "sample stack trace", DateCreated = DateTime.Now, isDeleted = false };
                Error err3 = new Error() { Message = "error 3", StackTrace = "sample stack trace", DateCreated = DateTime.Now, isDeleted = false };

                context.Errors.Add(err1);
                context.Errors.Add(err2);
                context.Errors.Add(err3);

                context.SaveChanges();
            }

            //Add Location
            if (!context.Locations.Any())
            {
                Location locations = new Location() { StreetNumber = 8, StreetName = "Plane Road", Town = "Kempton Park", City = "Johannesburg", Country = "South Africa", isDeleted = false };

                context.Locations.Add(locations);
                context.SaveChanges();
            }

            //Add Organisation

            if (!context.Organisations.Any())
            {
                Organisation Org1 = new Organisation() { LocationID = 1, OrganisationName = "Armour Foundation", Industry = "Education", isDeleted = false };

                context.Organisations.Add(Org1);
                context.SaveChanges();
            }

            if (!context.Departments.Any())
            {
                Department dep1 = new Department() { DepartmentName = "Sales", OrganisationID = 1, isDeleted = false };
                Department dep2 = new Department() { DepartmentName = "IT", OrganisationID = 1, isDeleted = false };
                Department dep3 = new Department() { DepartmentName = "Software Development", OrganisationID = 1, isDeleted = false };

                context.Departments.Add(dep1);
                context.Departments.Add(dep2);
                context.Departments.Add(dep3);

                context.SaveChanges();
            }


            //Add PasswordQsBanks
            if (!context.PasswordQsBanks.Any())
            {
                PasswordQsBank passQ = new PasswordQsBank() { PasswordQuestion = "In what city were you born?", isDeleted = false };
                PasswordQsBank passQ1 = new PasswordQsBank() { PasswordQuestion = "What high school did you attend?", isDeleted = false };
                PasswordQsBank passQ2 = new PasswordQsBank() { PasswordQuestion = "What is the name of your first school?", isDeleted = false };
                PasswordQsBank passQ3 = new PasswordQsBank() { PasswordQuestion = "What is your mother's maiden name?", isDeleted = false };
                PasswordQsBank passQ4 = new PasswordQsBank() { PasswordQuestion = "What is your father's middle name?", isDeleted = false };
                PasswordQsBank passQ5 = new PasswordQsBank() { PasswordQuestion = "What is your favorite color?", isDeleted = false };
                PasswordQsBank passQ6 = new PasswordQsBank() { PasswordQuestion = "What was your favorite place to visit as a child?", isDeleted = false };


                context.PasswordQsBanks.Add(passQ);
                context.PasswordQsBanks.Add(passQ1);
                context.PasswordQsBanks.Add(passQ2);
                context.PasswordQsBanks.Add(passQ3);
                context.PasswordQsBanks.Add(passQ4);
                context.PasswordQsBanks.Add(passQ5);
                context.PasswordQsBanks.Add(passQ6);

                context.SaveChanges();
            }

            //Add Provisioned
            if (!context.Provisioned.Any())
            {
                Provisioned prov = new Provisioned() { EmailAddress = "robmasango@gmail.com", RoleID = 1, isDeleted = false };

                context.Provisioned.Add(prov);
                context.SaveChanges();
            }

            //Add Roles
            if (!context.Roles.Any())
            {
                Role role = new Role() { Name = "Super Admin", Description = "Has full control", isDeleted = false };
                Role role1 = new Role() { Name = "Admin", Description = "Has limited control", isDeleted = false };
                Role role2 = new Role() { Name = "Employee", Description = "Access to Employee related objects", isDeleted = false };

                context.Roles.Add(role);
                context.Roles.Add(role1);
                context.Roles.Add(role2);
                context.SaveChanges();
            }


            ////Add Send Message
            //if (!context.SendShortMessages.Any())
            //{
            //    for (var i = 0; i <= 500; i++)
            //    {
            //        var f = new Faker();

            //        var sendMessage = new SendShortMessage
            //        {
            //            smsID = f.PickRandom(1, 2), 
            //            smsStatusID = f.PickRandom(1, 3),
            //            SurveyID = f.PickRandom(1, 350),
            //            isDeleted = false
            //        };

            //        context.SendShortMessages.Add(sendMessage);
            //        context.SaveChanges();
            //    }
            //}

            //Add Send SMS Status

            if (!context.SendSmsStatus.Any())
            {
                SendSmsStatus sms1 = new SendSmsStatus() { StatusDesc = "Success", isDeleted = false };
                SendSmsStatus sms2 = new SendSmsStatus() { StatusDesc = "Pending", isDeleted = false };
                SendSmsStatus sms3 = new SendSmsStatus() { StatusDesc = "Failed", isDeleted = false };

                context.SendSmsStatus.Add(sms1);
                context.SendSmsStatus.Add(sms2);
                context.SendSmsStatus.Add(sms3);
                context.SaveChanges();
            }

            //Add Short Messages

            if (!context.ShortMessages.Any())
            {
                SendSmsStatus sms1 = new SendSmsStatus() { StatusDesc = "Success", isDeleted = false };
                SendSmsStatus sms2 = new SendSmsStatus() { StatusDesc = "Pending", isDeleted = false };
                SendSmsStatus sms3 = new SendSmsStatus() { StatusDesc = "Failed", isDeleted = false };

                ShortMessage shortmes1 = new ShortMessage() { smsText = "Emplonomy - Please follow the link to complete your questionnaire", isDeleted = false };
                ShortMessage shortmes2 = new ShortMessage() { smsText = "Emplonomy - your shift (Shift Ref) has been bought", isDeleted = false };
                ShortMessage shortmes3 = new ShortMessage() { smsText = "Emplonomy - your shift purchace request (Shift Ref) has been declined", isDeleted = false };

                context.ShortMessages.Add(shortmes1);
                context.ShortMessages.Add(shortmes2);
                context.ShortMessages.Add(shortmes3);
                context.SaveChanges();
            }


            //-------------------------------------- Admin End --------------------------------------------------------------------


            //-------------------------------------- Survey Start --------------------------------------------------------------------
            

            // Add Survey Frequency
            if (!context.SurveyFrequencies.Any())
            {
                SurveyFrequency sf1 = new SurveyFrequency() { Name = "Weekly", NumQuestions = 5, isDeleted = false };
                SurveyFrequency sf2 = new SurveyFrequency() { Name = "Bi-weekly", NumQuestions = 11, isDeleted = false };
                SurveyFrequency sf3 = new SurveyFrequency() { Name = "Monthly ", NumQuestions = 22, isDeleted = false };
                SurveyFrequency sf4 = new SurveyFrequency() { Name = "Quarterly ", NumQuestions = 39, isDeleted = false };

                context.SurveyFrequencies.Add(sf1);
                context.SurveyFrequencies.Add(sf2);
                context.SurveyFrequencies.Add(sf3);
                context.SurveyFrequencies.Add(sf4);

                context.SaveChanges();
            }

            //Add Surveys
            if (!context.Surveys.Any())
            {
                Survey survey1 = new Survey() { OrganisationID = 1, FrequencyID = 1, Title = "Org1 Title", Version = 1, isDeleted = false };

                context.Surveys.Add(survey1);
                context.SaveChanges();
            }


            // Add Survey Questions
            if (!context.SurveyQuestions.Any())
            {
                SurveyQuestion sq1 = new SurveyQuestion()
                {   Driver = "Engagement",
                    SubDriver = "None",
                    Question = "How likely is it you would recommend [Company Name] as a place to work?",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 1,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq1);
                context.SaveChanges();

                SurveyQuestion sq2 = new SurveyQuestion()
                {
                    Driver = "Engagement",
                    SubDriver = "Belief",
                    Question = "How likely is it you would recommend [Company Name] products or services to friends and family?",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 2,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq2);
                context.SaveChanges();

                SurveyQuestion sq3 = new SurveyQuestion()
                {
                    Driver = "Engagement",
                    SubDriver = "Loyalty",
                    Question = " If you were offered the same job at another organization, how likely is it you would stay at [Company Name]?",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 3,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq3);
                context.SaveChanges();

                SurveyQuestion sq4 = new SurveyQuestion()
                {
                    Driver = "Engagement",
                    SubDriver = "Satisfaction",
                    Question = "Overall, how satisfied are you working at [Company Name]?",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 4,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq4);
                context.SaveChanges();

                SurveyQuestion sq5 = new SurveyQuestion()
                {
                    Driver = "Accomplishment",
                    SubDriver = "None",
                    Question = "Most days I feel a sense of accomplishment from what I do.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 5,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq5);
                context.SaveChanges();

                SurveyQuestion sq6 = new SurveyQuestion()
                {
                    Driver = "Accomplishment",
                    SubDriver = "Challenging",
                    Question = "I have the opportunity to do challenging things at work.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 6,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq6);
                context.SaveChanges();

                SurveyQuestion sq7 = new SurveyQuestion()
                {
                    Driver = "Autonomy",
                    SubDriver = "None",
                    Question = "I feel like I am given enough freedom to decide how to do my work.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 7,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq7);
                context.SaveChanges();

                SurveyQuestion sq8 = new SurveyQuestion()
                {
                    Driver = "Autonomy",
                    SubDriver = "Flexibility",
                    Question = "My work schedule is flexible enough to deal with family or personal life.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 8,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq8);
                context.SaveChanges();

                SurveyQuestion sq9 = new SurveyQuestion()
                {
                    Driver = "Autonomy",
                    SubDriver = "Remote work",
                    Question = "I am satisfied with our work from home policy.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 9,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq9);
                context.SaveChanges();

                SurveyQuestion sq10 = new SurveyQuestion()
                {
                    Driver = "Environment",
                    SubDriver = "None",
                    Question = "My workplace is free from distractions and I find it easy to focus on my work.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 10,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq10);
                context.SaveChanges();

                SurveyQuestion sq11 = new SurveyQuestion()
                {
                    Driver = "Environment",
                    SubDriver = "Collaboration",
                    Question = "I can easily find space away from my desk for conversations and collaboration with others.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 11,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq11);
                context.SaveChanges();

                SurveyQuestion sq12 = new SurveyQuestion()
                {
                    Driver = "Environment",
                    SubDriver = "Equipment",
                    Question = "I have the materials and equipment I need to do my job well.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 12,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq12);
                context.SaveChanges();

                SurveyQuestion sq13 = new SurveyQuestion()
                {
                    Driver = "Environment",
                    SubDriver = "Informal",
                    Question = "When I need a break, my workplace has spaces to chat and relax with others.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 13,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq13);
                context.SaveChanges();


                SurveyQuestion sq14 = new SurveyQuestion()
                {
                    Driver = "Freedom of opinions",
                    SubDriver = "None",
                    Question = "At work, my opinions seem to count.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 14,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq14);
                context.SaveChanges();

                SurveyQuestion sq15 = new SurveyQuestion()
                {
                    Driver = "Freedom of opinions",
                    SubDriver = "Manager",
                    Question = "My manager cares about my opinions.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 15,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq15);
                context.SaveChanges();

                SurveyQuestion sq16 = new SurveyQuestion()
                {
                    Driver = "Freedom of opinions",
                    SubDriver = "Team",
                    Question = "My co-workers welcome opinions different from their own.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 16,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq16);
                context.SaveChanges();

                SurveyQuestion sq17 = new SurveyQuestion()
                {
                    Driver = "Goal Setting",
                    SubDriver = "None",
                    Question = "At work, I know what is expected of me everyday.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 17,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq17);
                context.SaveChanges();

                SurveyQuestion sq18 = new SurveyQuestion()
                {
                    Driver = "Goal Setting",
                    SubDriver = "Alignment",
                    Question = "I understand how my work supports the goal(s) of my team and department. ",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 18,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq15);
                context.SaveChanges();

                SurveyQuestion sq19 = new SurveyQuestion()
                {
                    Driver = "Growth",
                    SubDriver = "None",
                    Question = "I feel that I’m growing professionally.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 19,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq19);
                context.SaveChanges();

                SurveyQuestion sq20 = new SurveyQuestion()
                {
                    Driver = "Growth",
                    SubDriver = "Career Development",
                    Question = "I see a path for me to advance my career in our organisation.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 20,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq20);
                context.SaveChanges();

                SurveyQuestion sq21 = new SurveyQuestion()
                {
                    Driver = "Growth",
                    SubDriver = "Learning",
                    Question = "My job enables me to learn and develop new skills.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 21,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq21);
                context.SaveChanges();

                SurveyQuestion sq22 = new SurveyQuestion()
                {
                    Driver = "Growth",
                    SubDriver = "Mentoring",
                    Question = "Either my manager or a mentor encourages and supports my development.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 22,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq22);
                context.SaveChanges();

                SurveyQuestion sq23 = new SurveyQuestion()
                {
                    Driver = "Management Support",
                    SubDriver = "None",
                    Question = "My manager provides me with the support I need to complete my work.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 23,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq23);
                context.SaveChanges();

                SurveyQuestion sq24 = new SurveyQuestion()
                {
                    Driver = "Management Support",
                    SubDriver = "Caring",
                    Question = "My manager cares about me as a person.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 24,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq24);
                context.SaveChanges();

                SurveyQuestion sq25 = new SurveyQuestion()
                {
                    Driver = "Meaningful Work",
                    SubDriver = "None",
                    Question = "The work I do is meaningful to me.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 25,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq25);
                context.SaveChanges();

                SurveyQuestion sq26 = new SurveyQuestion()
                {
                    Driver = "Meaningful Work",
                    SubDriver = "Fit",
                    Question = "At work, I have the opportunity to do what I do best every day.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 26,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq26);
                context.SaveChanges();

                SurveyQuestion sq27 = new SurveyQuestion()
                {
                    Driver = "Meaningful Work",
                    SubDriver = "Significance",
                    Question = "I make a difference in my team.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 27,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq27);
                context.SaveChanges();

                SurveyQuestion sq28 = new SurveyQuestion()
                {
                    Driver = "Organisational Fit",
                    SubDriver = "None",
                    Question = "The work I do is meaningful to me.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 28,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq28);
                context.SaveChanges();

                SurveyQuestion sq29 = new SurveyQuestion()
                {
                    Driver = "Organisational Fit",
                    SubDriver = "Fit",
                    Question = "At work, I have the opportunity to do what I do best every day.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 29,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq29);
                context.SaveChanges();

                SurveyQuestion sq30 = new SurveyQuestion()
                {
                    Driver = "Peer Relationships",
                    SubDriver = "None",
                    Question = "I can count on my co-workers to help out when needed.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 30,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq30);
                context.SaveChanges();

                SurveyQuestion sq31 = new SurveyQuestion()
                {
                    Driver = "Peer Relationships",
                    SubDriver = "Friends",
                    Question = "I consider the people I regularly interact with to be my friends.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 31,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq31);
                context.SaveChanges();

                SurveyQuestion sq32 = new SurveyQuestion()
                {
                    Driver = "Peer Relationships",
                    SubDriver = "Quality",
                    Question = "My coworkers are committed to doing quality work.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 32,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq32);
                context.SaveChanges();

                SurveyQuestion sq33 = new SurveyQuestion()
                {
                    Driver = "Recognition",
                    SubDriver = "None",
                    Question = "If I do great work, I know that it will be recognised.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 33,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq33);
                context.SaveChanges();

                SurveyQuestion sq34 = new SurveyQuestion()
                {
                    Driver = "Recognition",
                    SubDriver = "Performance",
                    Question = "I get enough feedback to understand if I’m doing my job well.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 34,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq31);
                context.SaveChanges();

                SurveyQuestion sq35 = new SurveyQuestion()
                {
                    Driver = "Reward",
                    SubDriver = "None",
                    Question = "I am fairly rewarded (e.g. pay, promotion, training) for my contributions to [Company Name].",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 35,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq35);
                context.SaveChanges();

                SurveyQuestion sq36 = new SurveyQuestion()
                {
                    Driver = "Reward",
                    SubDriver = "Discussion",
                    Question = "I can have well-informed and constructive conversations with my manager about pay.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 36,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq36);
                context.SaveChanges();

                SurveyQuestion sq37 = new SurveyQuestion()
                {
                    Driver = "Reward",
                    SubDriver = "Fairness",
                    Question = "I believe my effort, skill and experience are accurately reflected in my pay.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 37,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq37);
                context.SaveChanges();

                SurveyQuestion sq38 = new SurveyQuestion()
                {
                    Driver = "Reward",
                    SubDriver = "Process",
                    Question = "The processes for calculating pay in our organisation seem fair and unbiased.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 38,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq38);
                context.SaveChanges();

                SurveyQuestion sq39 = new SurveyQuestion()
                {
                    Driver = "Strategy",
                    SubDriver = "None",
                    Question = "The overall business goals and strategies set by senior leadership are taking [Company Name] in the right direction.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 39,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq39);
                context.SaveChanges();

                SurveyQuestion sq40 = new SurveyQuestion()
                {
                    Driver = "Strategy",
                    SubDriver = "Communication",
                    Question = "Our organisation does a good job of communicating the goals and strategies set by senior leadership.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 40,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq40);
                context.SaveChanges();

                SurveyQuestion sq41 = new SurveyQuestion()
                {
                    Driver = "Strategy",
                    SubDriver = "Mission",
                    Question = "I’m inspired by the purpose and mission of our organisation.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 41,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq41);
                context.SaveChanges();

                SurveyQuestion sq42 = new SurveyQuestion()
                {
                    Driver = "Workload",
                    SubDriver = "None",
                    Question = "I find my workload manageable.",
                    QuestionType = "Array (10 point choice)",
                    QuestionOrder = 42,
                    isDeleted = false
                };
                context.SurveyQuestions.Add(sq42);
                context.SaveChanges();

            }

            if (!context.SendShortMessages.Any())
            {
                for (var i = 0; i <= 150; i++)
                {
                    var f = new Faker();

                    var sendMessage = new SendShortMessage
                    {
                        smsID = f.Random.Int(1, 2),
                        smsStatusID = f.Random.Int(1, 2),
                        SurveyID = 1,
                        isDeleted = false
                    };

                    context.SendShortMessages.Add(sendMessage);
                    context.SaveChanges();
                }
            }

            //-------------------------------------- Survey End --------------------------------------------------------------------

            //-------------------------------------- User Start --------------------------------------------------------------------
            //Add Department Managers



            //Add EmplonomyUsers
            if (!context.EmplonomyUsers.Any())
            {
                for (var i = 1; i <= 1; i++)
                {
                    var f = new Faker();

                    var user = new EmplonomyUser()
                    {
                        DepartmentID = 1,
                        EmployeeNumber = "Emplonomy" + i,
                        EmailAddress = f.Internet.Email(),
                        PasswordHash = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                        PasswordSalt = "mNKLRbEFCH8y1xIyTXP4qA==",
                        PasswordQuestionID = 1,
                        PasswordAnswer = f.Random.ToString(),
                        isManager = true,
                        isOrgManager = true,
                        IDNumber = "880123511108" + i,
                        FirstName = f.Name.FirstName(),
                        MiddleName = f.Name.FirstName(),
                        LastName = f.Name.LastName(),
                        Birthdate = new DateTime(2017, 10, 20),
                        HireDate = new DateTime(2017, 10, 20),
                        ResignationDate = new DateTime(2017, 10, 20),
                        PhoneCell = "084092429" + i,
                        PhoneHome = "084092429" + i,
                        PhoneWork = "084092429" + i,
                        AvatarURL = "AvatarFilePath",
                        CreateDate = new DateTime(2017, 10, 20),
                        AgreeTC = true,
                        LastLoginDate = DateTime.Now,
                        FailedPasswordAttempts = 0,
                        IsLoggedin = true,
                        ConfirmedReg = true,
                        isDeleted = false,

                    };

                    int? a = null;
                    int b = (int)a;

                    context.Add(user);
                    context.SaveChanges();
                }

                for (var i = 2; i <= 2; i++)
                {
                    var f = new Faker();

                    var user = new EmplonomyUser()
                    {
                        DepartmentID = 1,
                        EmployeeNumber = "Emplonomy" + i,
                        EmailAddress = f.Internet.Email(),
                        PasswordHash = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                        PasswordSalt = "mNKLRbEFCH8y1xIyTXP4qA==",
                        PasswordQuestionID = 1,
                        PasswordAnswer = f.Random.ToString(),
                        isManager = true,
                        isOrgManager = false,
                        IDNumber = "880123511108" + i,
                        FirstName = f.Name.FirstName(),
                        MiddleName = f.Name.FirstName(),
                        LastName = f.Name.LastName(),
                        Birthdate = new DateTime(2017, 10, 20),
                        HireDate = new DateTime(2017, 10, 20),
                        ResignationDate = new DateTime(2017, 10, 20),
                        PhoneCell = "084092429" + i,
                        PhoneHome = "084092429" + i,
                        PhoneWork = "084092429" + i,
                        AvatarURL = "AvatarFilePath",
                        CreateDate = new DateTime(2017, 10, 20),
                        AgreeTC = true,
                        LastLoginDate = DateTime.Now,
                        FailedPasswordAttempts = 0,
                        IsLoggedin = true,
                        ConfirmedReg = true,
                        isDeleted = false,
                    };

                    context.Add(user);
                    context.SaveChanges();
                }

                for (var i = 3; i <= 20; i++)
                {
                    var f = new Faker();

                    var user = new EmplonomyUser()
                    {
                        DepartmentID = 1,
                        EmployeeNumber = "Emplonomy" + i,
                        EmailAddress = f.Internet.Email(),
                        PasswordHash = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                        PasswordSalt = "mNKLRbEFCH8y1xIyTXP4qA==",
                        PasswordQuestionID = 1,
                        PasswordAnswer = f.Random.ToString(),
                        isManager = false,
                        isOrgManager = false,
                        IDNumber = "880123511108" + i,
                        FirstName = f.Name.FirstName(),
                        MiddleName = f.Name.FirstName(),
                        LastName = f.Name.LastName(),
                        Birthdate = new DateTime(2017, 10, 20),
                        HireDate = new DateTime(2017, 10, 20),
                        ResignationDate = new DateTime(2017, 10, 20),
                        PhoneCell = "084092429" + i,
                        PhoneHome = "084092429" + i,
                        PhoneWork = "084092429" + i,
                        AvatarURL = "AvatarFilePath",
                        CreateDate = new DateTime(2017, 10, 20),
                        AgreeTC = true,
                        LastLoginDate = DateTime.Now,
                        FailedPasswordAttempts = 0,
                        IsLoggedin = true,
                        ConfirmedReg = true,
                        isDeleted = false,
                    };

                    context.Add(user);
                    context.SaveChanges();
                }
            }

            //Add Department Managers
            if (!context.DepartmentManagers.Any())
            {
                DepartmentManager dep1 = new DepartmentManager() { DepartmentID = 1, ManagerID = 5, isDeleted = false };
                DepartmentManager dep2 = new DepartmentManager() { DepartmentID = 3, ManagerID = 7, isDeleted = false };

                context.DepartmentManagers.Add(dep1);
                context.DepartmentManagers.Add(dep2);

                context.SaveChanges();
            }

            if (!context.OrganisationManagers.Any())
            {
                OrganisationManager org1 = new OrganisationManager() { OrganisationID = 1, ManagerID = 4, isDeleted = false };

                context.OrganisationManagers.Add(org1);

                context.SaveChanges();
            }

            //Add Survy responses
            if (!context.SurveyResponses.Any())
            {
                for (var a = 1; a <= 20; a++)
                {
                    for (var i = 1; i <= 39; i++)
                    {
                        var f = new Faker();

                        var surveyres = new SurveyResponse()
                        {
                            SurveyID = 1,
                            QuestionID = i,
                            UserID = f.Random.Int(1, 20),       
                            Answer = f.Random.Int(1,20),
                            isDeleted = false
                        };

                        context.SurveyResponses.Add(surveyres);
                        context.SaveChanges();
                    }
                }
            }

            //Add user addresses
            if (!context.UserAddresses.Any())
            {
                for (var i = 1; i <= 20; i++)
                {
                    var f = new Faker();

                    var address = new UserAddress()
                    {
                        UserID = f.Random.Int(1, 20),
                        AddressTypeID = f.Random.Int(1, 3),
                        PrefferedAddress = true,
                        StreetAddress = f.Address.StreetAddress(),
                        Town = f.Address.City(),
                        City = f.Address.City(),
                        Province = f.Address.State(),
                        Country = f.Address.Country(),
                        PostalCode = f.Address.ZipCode(),
                        isDeleted = false
                    };

                    context.UserAddresses.Add(address);
                    context.SaveChanges();
                }
            }


            if (!context.UserRoles.Any())
            {
                for (var i = 1; i <= 20; i++)
                {
                    var f = new Faker();

                    var roles = new UserRole()
                    {
                        UserID = f.Random.Int(1, 20),
                        RoleID = f.Random.Int(1, 3),
                        isDeleted = false
                    };

                    context.UserRoles.Add(roles);
                    context.SaveChanges();
                }
            }
            //-------------------------------------- User End --------------------------------------------------------------------

        }
    }
}
