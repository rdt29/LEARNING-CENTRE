using AutoMapper;
using LearningCentre.Core.Contract;
using LearningCentre.Core.Domain.RequestModel;
using LearningCentre.Core.Domain.ResponseModel;
using LearningCentre.Core.Services.Helper.Interface;
using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Domain.Entities;
using LearningCentre.Shared;
using System.Security.Cryptography;
using System.Text;

namespace LearningCentre.Core.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IGenerateToken _generateToken;
        private readonly IUserRepository @object;
        private readonly IMapper mapper;
        private readonly IMailServices _mailServices;

        public UserServices(IUserRepository userRepository, IMapper mapper, IGenerateToken generateToken, IMailServices mailServices)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _mailServices = mailServices;
            _generateToken = generateToken;
        }

        //public async Task<List<UserResponseMOdel>> GetUserAsync()
        //{
        //    try
        //    {
        //        var user = await _userRepository.GetUsers();
        //        var result = _mapper.Map<List<UserResponseMOdel>>(user);
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public async Task<PagedList<UserResponseMOdel>> GetUserAsync(int page = 1, int pageSize = 25)
        {
            try
            {
                var user = await _userRepository.GetUsers(page, pageSize);
                var result = _mapper.Map<PagedList<UserResponseMOdel>>(user);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserResponseMOdel> GetUserByIdAsync(int Id)
        {
            try
            {
                var user = await _userRepository.GetUserById(Id);
                var result = _mapper.Map<UserResponseMOdel>(user);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserResponseMOdel> AddUserAsync(UserRequestModel userRequestModel)
        {
            try
            {
                var hmac = new HMACSHA512();
                var passwordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(userRequestModel.Password));
                var passwordSalt = hmac.Key;

                List<UserRoleMapping> roles = new List<UserRoleMapping>();

                for (var i = 0; i < userRequestModel.RoleId.Length; i++)
                {
                    UserRoleMapping users = new UserRoleMapping();

                    users.RoleId = userRequestModel.RoleId[i];
                    users.TechnologyId = userRequestModel.TechnologyId[i];

                    roles.Add(users);
                };

                User user = new User()
                {
                    FirstName = userRequestModel.FirstName,
                    LastName = userRequestModel.LastName,
                    // Role = userRequestModel.Role,
                    Email = userRequestModel.Email,
                    PasswordHash = passwordHash,

                    PasswordSalt = passwordSalt,
                    CreatedOn = DateTimeOffset.Now,
                    UserRoleMapping = roles,
                };

                var User = await _userRepository.AddUser(user);
                var UserResponse = _mapper.Map<UserResponseMOdel>(user);

                var name = userRequestModel.FirstName + " " + userRequestModel.LastName;
                var htmlcontent = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>\r\n<html data-editor-version='2' class='sg-campaigns' xmlns='http://www.w3.org/1999/xhtml'>\r\n\r\n<head>\r\n  <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />\r\n  <meta name='viewport' content='width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1' />\r\n  <!--[if !mso]><!-->\r\n  <meta http-equiv='X-UA-Compatible' content='IE=Edge' />\r\n  <!--<![endif]-->\r\n  <!--[if (gte mso 9)|(IE)]>\r\n      <xml>\r\n        <o:OfficeDocumentSettings>\r\n          <o:AllowPNG />\r\n          <o:PixelsPerInch>96</o:PixelsPerInch>\r\n        </o:OfficeDocumentSettings>\r\n      </xml>\r\n    <![endif]-->\r\n  <!--[if (gte mso 9)|(IE)]>\r\n      <style type='text/css'>\r\n        body {\r\n          width: 600px;\r\n          margin: 0 auto;\r\n        }\r\n        table {\r\n          border-collapse: collapse;\r\n        }\r\n        table,\r\n        td {\r\n          mso-table-lspace: 0pt;\r\n          mso-table-rspace: 0pt;\r\n        }\r\n        img {\r\n          -ms-interpolation-mode: bicubic;\r\n        }\r\n      </style>\r\n    <![endif]-->\r\n  <style type='text/css'>\r\n    body,\r\n    p,\r\n    div {\r\n      font-family: inherit;\r\n      font-size: 14px;\r\n    }\r\n\r\n    body {\r\n      color: #000000;\r\n    }\r\n\r\n    body a {\r\n      color: #1188e6;\r\n      text-decoration: none;\r\n    }\r\n\r\n    p {\r\n      margin: 0;\r\n      padding: 0;\r\n    }\r\n\r\n    table.wrapper {\r\n      width: 100% !important;\r\n      table-layout: fixed;\r\n      -webkit-font-smoothing: antialiased;\r\n      -webkit-text-size-adjust: 100%;\r\n      -moz-text-size-adjust: 100%;\r\n      -ms-text-size-adjust: 100%;\r\n    }\r\n\r\n    img.max-width {\r\n      max-width: 100% !important;\r\n    }\r\n\r\n    .column.of-2 {\r\n      width: 50%;\r\n    }\r\n\r\n    .column.of-3 {\r\n      width: 33.333%;\r\n    }\r\n\r\n    .column.of-4 {\r\n      width: 25%;\r\n    }\r\n\r\n    ul ul ul ul {\r\n      list-style-type: disc !important;\r\n    }\r\n\r\n    ol ol {\r\n      list-style-type: lower-roman !important;\r\n    }\r\n\r\n    ol ol ol {\r\n      list-style-type: lower-latin !important;\r\n    }\r\n\r\n    ol ol ol ol {\r\n      list-style-type: decimal !important;\r\n    }\r\n\r\n    @media screen and (max-width: 480px) {\r\n\r\n      .preheader .rightColumnContent,\r\n      .footer .rightColumnContent {\r\n        text-align: left !important;\r\n      }\r\n\r\n      .preheader .rightColumnContent div,\r\n      .preheader .rightColumnContent span,\r\n      .footer .rightColumnContent div,\r\n      .footer .rightColumnContent span {\r\n        text-align: left !important;\r\n      }\r\n\r\n      .preheader .rightColumnContent,\r\n      .preheader .leftColumnContent {\r\n        font-size: 80% !important;\r\n        padding: 5px 0;\r\n      }\r\n\r\n      table.wrapper-mobile {\r\n        width: 100% !important;\r\n        table-layout: fixed;\r\n      }\r\n\r\n      img.max-width {\r\n        height: auto !important;\r\n        max-width: 100% !important;\r\n      }\r\n\r\n      a.bulletproof-button {\r\n        display: block !important;\r\n        width: auto !important;\r\n        font-size: 80%;\r\n        padding-left: 0 !important;\r\n        padding-right: 0 !important;\r\n      }\r\n\r\n      .columns {\r\n        width: 100% !important;\r\n      }\r\n\r\n      .column {\r\n        display: block !important;\r\n        width: 100% !important;\r\n        padding-left: 0 !important;\r\n        padding-right: 0 !important;\r\n        margin-left: 0 !important;\r\n        margin-right: 0 !important;\r\n      }\r\n\r\n      .social-icon-column {\r\n        display: inline-block !important;\r\n      }\r\n    }\r\n  </style>\r\n  <!--user entered Head Start-->\r\n  <link href='https://fonts.googleapis.com/css?family=Fira+Sans+Condensed&display=swap' rel='stylesheet' />\r\n  <style>\r\n    body {\r\n      font-family: 'Fira Sans Condensed', sans-serif;\r\n    }\r\n  </style>\r\n  <!--End Head user entered-->\r\n</head>\r\n\r\n<body>\r\n  <center class='wrapper' data-link-color='#1188E6' data-body-style='font-size:14px; font-family:inherit; color:#000000; background-color:#f0f0f0;'>\r\n    <div class='webkit'>\r\n      <table cellpadding='0' cellspacing='0' border='0' width='100%' class='wrapper' bgcolor='#f0f0f0'>\r\n        <tr>\r\n          <td valign='top' bgcolor='#f0f0f0' width='100%'>\r\n            <table width='100%' role='content-container' class='outer' align='center' cellpadding='0' cellspacing='0' border='0'>\r\n              <tr>\r\n                <td width='100%'>\r\n                  <table width='100%' cellpadding='0' cellspacing='0' border='0'>\r\n                    <tr>\r\n                      <td>\r\n                        <!--[if mso]>\r\n    <center>\r\n    <table><tr><td width='600'>\r\n  <![endif]-->\r\n                        <table width='100%' cellpadding='0' cellspacing='0' border='0' style='width: 100%; max-width: 600px' align='center'>\r\n                          <tr>\r\n                            <td role='modules-container' style='\r\n                                  padding: 0px 0px 0px 0px;\r\n                                  color: #000000;\r\n                                  text-align: left;\r\n                                ' bgcolor='#FFFFFF' width='100%' align='left'>\r\n                              <table class='module preheader preheader-hide' role='module' data-type='preheader' border='0' cellpadding='0' cellspacing='0' width='100%' style='\r\n                                    display: none !important;\r\n                                    mso-hide: all;\r\n                                    visibility: hidden;\r\n                                    opacity: 0;\r\n                                    color: transparent;\r\n                                    height: 0;\r\n                                    width: 0;\r\n                                  '>\r\n                                <tr>\r\n                                  <td role='module-content'>\r\n                                    <p></p>\r\n                                  </td>\r\n                                </tr>\r\n                              </table>\r\n                              <table border='0' cellpadding='0' cellspacing='0' align='center' width='100%' role='module' data-type='columns' style='padding: 30px 0px 30px 20px' bgcolor='#4d5171' data-distribution='1'>\r\n                                <tbody>\r\n                                  <tr role='module-content'>\r\n                                    <td height='100%' valign='top'>\r\n                                      <table width='560' style='\r\n                                            width: 560px;\r\n                                            border-spacing: 0;\r\n                                            border-collapse: collapse;\r\n                                            margin: 0px 10px 0px 10px;\r\n                                          ' cellpadding='0' cellspacing='0' align='left' border='0' bgcolor='' class='column column-0'>\r\n                                        <tbody>\r\n                                          <tr>\r\n                                            <td style='\r\n                                                  padding: 0px;\r\n                                                  margin: 0px;\r\n                                                  border-spacing: 0;\r\n                                                '>\r\n                                              <table class='wrapper' role='module' data-type='image' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed' data-muid='a169501c-69eb-4f62-ad93-ac0150abdf03'>\r\n                                                <tbody>\r\n                                                  <tr>\r\n                                                    <td style='\r\n                                                          font-size: 6px;\r\n                                                          line-height: 10px;\r\n                                                          padding: 0px 0px 0px\r\n                                                            0px;\r\n                                                        ' valign='top' align='left'>\r\n                                                      <img class='max-width' border='0' style='\r\n  display: block;\r\n  color: #000000;\r\n                                                            text-decoration: none;\r\n                                                            font-family: Helvetica,\r\n                                                              arial, sans-serif;\r\n                                                            font-size: 16px;\r\n                                                          ' width='154' alt='' data-proportionally-constrained='true' data-responsive='false' src='data:image/png;base64,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' height='32' />\r\n                                                    </td>\r\n                                                  </tr>\r\n                                                </tbody>\r\n                                              </table>\r\n                                            </td>\r\n                                          </tr>\r\n                                        </tbody>\r\n                                      </table>\r\n                                    </td>\r\n                                  </tr>\r\n                                </tbody>\r\n                              </table>\r\n                              <table class='module' role='module' data-type='text' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed' data-muid='080768f5-7b16-4756-a254-88cfe5138113' data-mc-module-version='2019-10-22'>\r\n                                <tbody>\r\n                                  <tr>\r\n                                    <td style='\r\n                                          padding: 30px 30px 18px 30px;\r\n                                          line-height: 36px;\r\n                                          text-align: inherit;\r\n                                          background-color: #4d5171;\r\n                                        ' height='100%' valign='top' bgcolor='#4d5171' role='module-content'>\r\n                                      <div>\r\n                                        <div style='\r\n                                              font-family: inherit;\r\n                                              text-align: center;\r\n                                            '>\r\n                                          <span style='\r\n                                                color: #ffffff;\r\n                                                font-size: 48px;\r\n                                                font-family: inherit;\r\n                                              '>Welcome," + name + "!</span>\r\n                                        </div>\r\n                                        <div></div>\r\n                                      </div>\r\n                                    </td>\r\n                                  </tr>\r\n                                </tbody>\r\n                              </table>\r\n                              <table class='module' role='module' data-type='text' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed' data-muid='cddc0490-36ba-4b27-8682-87881dfbcc14' data-mc-module-version='2019-10-22'>\r\n                                <tbody>\r\n                                  <tr>\r\n                                    <td style='\r\n                                          padding: 18px 30px 18px 30px;\r\n                                          line-height: 22px;\r\n                                          text-align: inherit;\r\n                                          background-color: #4d5171;\r\n                                        ' height='100%' valign='top' bgcolor='#4d5171' role='module-content'>\r\n                                      <div>\r\n                                        <div style='\r\n                                              font-family: inherit;\r\n                                              text-align: inherit;\r\n                                            '>\r\n                                          <span style='\r\n                                                color: #ffffff;\r\n                                                font-size: 15px;\r\n                                              '>Thanks so much for joining\r\n                                            Learning Center we're thrilled\r\n                                            to\r\n                                            have you!</span>\r\n                                        </div>\r\n                                        <div></div>\r\n                                      </div>\r\n                                    </td>\r\n                                  </tr>\r\n                                </tbody>\r\n                              </table>\r\n                              <table border='0' cellpadding='0' cellspacing='0' class='module' data-role='module-button' data-type='button' role='module' style='table-layout: fixed' width='100%' data-muid='cd669415-360a-41a6-b4b4-ca9e149980b3'>\r\n                                <tbody>\r\n                                  <tr>\r\n                                    <td align='center' bgcolor='#4d5171' class='outer-td' style='\r\n                                          padding: 10px 0px 40px 0px;\r\n                                          background-color: #4d5171;\r\n                                        '>\r\n                                      <table border='0' cellpadding='0' cellspacing='0' class='wrapper-mobile' style='text-align: center'>\r\n                                        <tbody>\r\n                                          <tr>\r\n                                            <td align='center' bgcolor='#ffc94c' class='inner-td' style='\r\n                                                  border-radius: 6px;\r\n                                                  font-size: 16px;\r\n                                                  text-align: center;\r\n                                                  background-color: inherit;\r\n                                                '>\r\n                                              <a href='' style='\r\n                                                    background-color: #ffc94c;\r\n                                                    border: 1px solid #ffc94c;\r\n                                                    border-color: #ffc94c;\r\n                                                    border-radius: 40px;\r\n                                                    border-width: 1px;\r\n                                                    color: #3f4259;\r\n                                                    display: inline-block;\r\n                                                    font-size: 15px;\r\n                                                    font-weight: normal;\r\n                                                    letter-spacing: 0px;\r\n                                                    line-height: 25px;\r\n                                                    padding: 12px 18px 10px 18px;\r\n                                                    text-align: center;\r\n                                                    text-decoration: none;\r\n                                                    border-style: solid;\r\n                                                    font-family: inherit;\r\n                                                    width: 168px;\r\n                                                  ' target='_blank'>Your Registration was Successful!</a>\r\n                                            </td>\r\n                                          </tr>\r\n                                        </tbody>\r\n                                      </table>\r\n                                    </td>\r\n                                  </tr>\r\n                                </tbody>\r\n                              </table>\r\n\r\n\r\n                              <table class='module' role='module' data-type='divider' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed' data-muid='c5a3c312-4d9d-44ff-9fce-6a8003caeeca.1'>\r\n                                <tbody>\r\n                                  <tr>\r\n                                    <td style='padding: 0px 20px 0px 20px' role='module-content' height='100%' valign='top' bgcolor='#4d5171'>\r\n                                      <table border='0' cellpadding='0' cellspacing='0' align='center' width='100%' height='1px' style='\r\n                                            line-height: 1px;\r\n                                            font-size: 1px;\r\n                                          '>\r\n                                        <tbody>\r\n                                          <tr>\r\n                                            <td style='padding: 0px 0px 1px 0px' bgcolor='#ffc94c'></td>\r\n                                          </tr>\r\n                                        </tbody>\r\n                                      </table>\r\n                                    </td>\r\n                                  </tr>\r\n                                </tbody>\r\n                              </table>\r\n                              <table class='module' role='module' data-type='text' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed' data-muid='eb301547-da19-441f-80a1-81e1b56e64ad.1' data-mc-module-version='2019-10-22'>\r\n                                <tbody>\r\n                                  <tr>\r\n                                    <td style='\r\n                                          padding: 30px 0px 18px 0px;\r\n                                          line-height: 22px;\r\n                                          text-align: inherit;\r\n                                          background-color: #4d5171;\r\n                                        ' height='100%' valign='top' bgcolor='#4d5171' role='module-content'>\r\n                                      <div>\r\n                                        <div style='\r\n                                              font-family: inherit;\r\n                                              text-align: center;\r\n                                            '>\r\n                                          <span style='\r\n                                                color: #ffc94c;\r\n                                                font-size: 20px;\r\n                                              '><strong> </strong></span>\r\n                                        </div>\r\n                                        <div></div>\r\n                                      </div>\r\n                                    </td>\r\n                                  </tr>\r\n                                </tbody>\r\n                              </table>\r\n                              <table border='0' cellpadding='0' cellspacing='0' align='center' width='100%' role='module' data-type='columns' style='padding: 10px 20px 0px 20px' bgcolor='#4d5171' data-distribution='1'>\r\n                                <tbody>\r\n                                  <tr role='module-content'>\r\n                                    <td height='100%' valign='top'>\r\n                                      <table width='540' style='\r\n                                            width: 540px;\r\n                                            border-spacing: 0;\r\n                                            border-collapse: collapse;\r\n                                            margin: 0px 10px 0px 10px;\r\n                                          ' cellpadding='0' cellspacing='0' align='left' border='0' bgcolor='' class='column column-0'>\r\n                                        <tbody>\r\n                                          <tr>\r\n                                            <td style='\r\n                                                  padding: 0px;\r\n                                                  margin: 0px;\r\n                                                  border-spacing: 0;\r\n                                                '>\r\n                                              <table class='wrapper' role='module' data-type='image' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed' data-muid='e57bf5b4-b40f-4703-95b4-d4fd8a88c51a'>\r\n                                                <tbody>\r\n                                                  <tr>\r\n                                                    <td style='\r\n                                                          font-size: 6px;\r\n                                                          line-height: 10px;\r\n                                                          padding: 0px 0px 0px\r\n                                                            0px;\r\n                                                        ' valign='top' align='center'>\r\n                                                      <img class='max-width' border='0' style='\r\n                                                            display: block;\r\n                                                            color: #000000;\r\n                                                            text-decoration: none;\r\n                                                            font-family: Helvetica,\r\n                                                              arial, sans-serif;\r\n                                                            font-size: 16px;\r\n                                                            max-width: 100% !important;\r\n                                                            width: 100%;\r\n                                                            height: auto !important;\r\n                                                          ' width='540' alt='' data-proportionally-constrained='true' data-responsive='true' src='http://cdn.mcauto-images-production.sendgrid.net/954c252fedab403f/1d47bb6e-fe00-41af-8044-5145b67e8d3a/459x314.png' />\r\n                                                    </td>\r\n                                                  </tr>\r\n                                                </tbody>\r\n                                              </table>\r\n                                              <table class='module' role='module' data-type='text' border='0' cellpadding='0' cellspacing='0' width='100%' style='table-layout: fixed' data-muid='ee038ca1-817c-4dfa-8961-7b61876b9929' data-mc-module-version='2019-10-22'>\r\n                                                <tbody>\r\n                                                  <tr>\r\n                                                    <td style='\r\n                                                          padding: 18px 0px 18px\r\n                                                            0px;\r\n                                                          line-height: 22px;\r\n                                                          text-align: inherit;\r\n                                                        ' height='100%' valign='top' bgcolor='' role='module-content'>\r\n                                                      <div>\r\n                                                        <div style='\r\n                                                              font-family: inherit;\r\n                                                              text-align: inherit;\r\n                                                            '>\r\n                                                          <span style='\r\n                                                                color: #ffffff;\r\n                                                                font-size: 15px;\r\n                                                              '></span><span style='\r\n                                                                color: #ffc94c;\r\n                                                                font-size: 15px;\r\n                                                              '><strong></strong></span><span style='\r\n                                                                color: #ffffff;\r\n                                                                font-size: 15px;\r\n                                                              '>.</span>\r\n                                                        </div>\r\n                                                        <div>\r\n                                                        </div>\r\n                                                      </div>\r\n                                                    </td>\r\n                                                  </tr>\r\n                                                </tbody>\r\n                                              </table>\r\n                                            </td>\r\n                                          </tr>\r\n                                        </tbody>\r\n                                      </table>\r\n                                    </td>\r\n                                  </tr>\r\n                                </tbody>\r\n                              </table>\r\n\r\n\r\n\r\n                              <div data-role='module-unsubscribe' class='module' role='module' data-type='unsubscribe' style='\r\n                                    color: #444444;\r\n                                    font-size: 12px;\r\n                                    line-height: 20px;\r\n                                    padding: 16px 16px 16px 16px;\r\n                                    text-align: Center;\r\n                                  ' data-muid='4e838cf3-9892-4a6d-94d6-170e474d21e5'>\r\n                                <p style='font-size: 12px; line-height: 20px'>\r\n                                  <a class='Unsubscribe--unsubscribeLink' href='{{{unsubscribe}}}' target='_blank' style=''>Unsubscribe</a>\r\n                                  -\r\n                                  <a href='{{{unsubscribe_preferences}}}' target='_blank' class='Unsubscribe--unsubscribePreferences' style=''>Unsubscribe Preferences</a>\r\n                                </p>\r\n                              </div>\r\n                              <table border='0' cellpadding='0' cellspacing='0' class='module' data-role='module-button' data-type='button' role='module' style='table-layout: fixed' width='100%' data-muid='5f89d789-2bfd-48e2-a219-1de42476c398'>\r\n\r\n                            </td>\r\n                          </tr>\r\n                        </table>\r\n                        <!--[if mso]>\r\n                                  </td>\r\n                                </tr>\r\n                              </table>\r\n                            </center>\r\n                            <![endif]-->\r\n                      </td>\r\n                    </tr>\r\n                  </table>\r\n                </td>\r\n              </tr>\r\n            </table>\r\n          </td>\r\n        </tr>\r\n      </table>\r\n    </div>\r\n  </center>\r\n</body>\r\n\r\n</html>";
                var planeContent = "";
                var subject = "New User";

                await _mailServices.SendGridMailSend(userRequestModel.Email, htmlcontent, planeContent, subject);
                
                return UserResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateUserAsync(int Id, UserUpdateReqModel userUpdateReqModel)
        {
            try
            {
                var user = await _userRepository.GetUserById(Id);
                if (user == null)
                {
                    throw new Exception("No user Found");
                }
                user.UpdateUser(userUpdateReqModel.FirstName, userUpdateReqModel.LastName, userUpdateReqModel.Email);
                user.UpdatedOn = DateTimeOffset.Now;
                var count = await _userRepository.UpdateUser(Id, user);
                return (count);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteUserAsync(int Id, UserDeleteRequestModel UserDeleteRequestModel)
        {
            try
            {
                var user = await _userRepository.GetUserById(Id);
                if (user == null)
                {
                    throw new Exception($"{Id} is not found");
                }

                var count = await _userRepository.DeleteUser(Id, user);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UserLogin(UserLoginReqModel userLoginReqModel)
        {
            var user = await _userRepository.UserLogin(userLoginReqModel.Email);

            if (user == null)
            {
                return ("User Not Found");
            }
            if (!VerifyPasswordHash(userLoginReqModel.Password, user.PasswordHash, user.PasswordSalt))
            {
                return ("Wrong Password");
            }
            else
            {
                var token = await _generateToken.TokenGenerate(user);
                return token;
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public async Task<TranieeViewAssignTaskResponseDTO> GetAssignTaskAsync(int Id)
        {
            try
            {
                var task = await _userRepository.GetTaskAssign(Id);

                TranieeViewAssignTaskResponseDTO obj = new TranieeViewAssignTaskResponseDTO()
                {
                    UserName = task.FirstName + " " + task.LastName,

                    Details = task.AssignTasks.Select(x => new TranieeViewTaskDetailsResponseDTO()
                    {
                        TaskId = x.TaskId,
                        Description = x.Task.TaskDescription,
                        Details = x.Task.TaskDescription,
                        MentorId = x.Task.UserId,
                        FileUrl = x.Task.DocumentURL,
                        DeadLine = (DateTimeOffset)x.DeadLine,
                        //Status = x.SubmittedTasks.Status,
                    })
                };
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}