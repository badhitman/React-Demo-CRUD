////////////////////////////////////////////////
// � https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SPADemoCRUD.Models;
using SPADemoCRUD.Models.view.menu;

namespace SPADemoCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetMenu : ControllerBase
    {
        private static readonly NestedMenu my = new NestedMenu()
        {
            Title = "My",
            Href = "#",
            Tooltip = "������ ������������",
            Childs = new MenuItem[]
            {
                new MenuItem() { Title = "���������", Href = "/notifications/", Tooltip = "��� �����������" },
                new MenuItem() { Title = "�������", Href = "/profile/", Tooltip = "��� ���������" },
                null,
                new MenuItem() { Title = "�����", Href = "/signin/", Tooltip = "����� �� ����������" }
            }
        };
        private static readonly NestedMenu users = new NestedMenu()
        {
            Title = "������������",
            Href = "#",
            Tooltip = "���������� ��������������",
            Childs = new MenuItem[]
            {
                new MenuItem() { Title = "������������", Href = "/users/list", Tooltip = "������� ������������������ ����������" },
                new MenuItem() { Title = "������", Href = "/departments/list", Tooltip = "������ � ������������" }
            }
        };
        private static readonly NestedMenu catalogues = new NestedMenu()
        {
            Title = "��������",
            Href = "#",
            Tooltip = "����������� � ������ ������",
            Childs = new MenuItem[]
            {
                new MenuItem() { Title = "������������", Href = "/goods/list", Tooltip = "������ � �� �����" },
                new MenuItem() { Title = "������", Href = "/addresses/list", Tooltip = "�������� �������������" }
            }
        };
        private static readonly NestedMenu server = new NestedMenu()
        {
            Title = "������",
            Href = "#",
            Tooltip = "���������� ��������",
            Childs = new MenuItem[]
            {
                new MenuItem() { Title = "���������", Href = "/server/list", Tooltip = "��������� �������/�������" },
                new MenuItem() { Title = "���������", Href = "/server/view", Tooltip = "��������� �������" }
            }
        };

        // GET: api/getmenu
        [HttpGet]
        public ActionResult<IEnumerable<MenuItem>> GetUsers()
        {
            AccessLevelUserRolesEnum role = User.HasClaim(c => c.Type == ClaimTypes.Role)
                ? (AccessLevelUserRolesEnum)Enum.Parse(typeof(AccessLevelUserRolesEnum), User.FindFirst(c => c.Type == ClaimTypes.Role).Value)
                : AccessLevelUserRolesEnum.Guest;

            switch (role)
            {
                case AccessLevelUserRolesEnum.Auth:
                    return new NestedMenu[] { my };
                case AccessLevelUserRolesEnum.Verified:
                    return new NestedMenu[] { my };
                case AccessLevelUserRolesEnum.Privileged:
                    return new NestedMenu[] { my };
                case AccessLevelUserRolesEnum.Manager:
                    return new NestedMenu[] { users, my };
                case AccessLevelUserRolesEnum.Admin:
                    return new NestedMenu[] { users, catalogues, my };
                case AccessLevelUserRolesEnum.ROOT:
                    return new NestedMenu[] { users, catalogues, server, my };
                default:
                    return new MenuItem[]
                    {
                        new MenuItem()
                        {
                            Title = "����",
                            Href = "/signin/",
                            Tooltip = "�����������/�����������"
                        }
                    };
            }
        }
    }
}
