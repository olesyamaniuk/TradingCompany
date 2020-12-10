using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using DTO;
using Dal;
using DAL.Interfaces;
using Dal.Concrete;
using Dal.Interfaces;
using BusinessLogic;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using WF.Models.Interfaces;
using WF.Models.Concrete;
using Unity.Resolution;
using NLog;

namespace WF
{
    static class Program
    {
        public static UnityContainer Container;
        public static IApplicationUser _user;
        public static Logger log = LogManager.GetCurrentClassLogger();
        [STAThread]
        static void Main()
        {
            ConfigureUnity();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _user = new ApplicationUser();

            
            LoginForm lf = Container.Resolve<LoginForm>(new ResolverOverride[] { new ParameterOverride("user", _user) });

            if (lf.ShowDialog() == DialogResult.OK)
            {
                log.Info("UserLogined. Username: {0}",_user.Login);
                Application.Run(Container.Resolve<UserStartPage>(new ResolverOverride[] {new ParameterOverride("user", _user)}));
            }
            else
            {
               log.Info("Exit ");
               Application.Exit();
            }



        }
        private static void ConfigureUnity()
        {
            

            Container = new UnityContainer();
            Container.RegisterInstance<IMapper>(config.CreateMapper());

            Container.RegisterType<IAccountDal, AccountDal>()
                     .RegisterType<IAdressDal, AdressDal>()
                     .RegisterType<ICardInfoDal, CardInfoDal>()
                     .RegisterType<ICategoryDal, CategoryDal>()
                     .RegisterType<IItemDal, ItemDal>()
                     .RegisterType<IOrderDal, OrderDal>()
                     .RegisterType<IOrderedDal, OrderedDal>()
                     .RegisterType<IOrderStatusDal, OrderStatusDal>()
                     .RegisterType<IUserInfoDal, UserInfoDal>()
                     .RegisterType<IUserInfo,UserInfo>()
                     .RegisterType<IAdress, Adress>()
                     .RegisterType<ICategory,Category>()
                     .RegisterType<IItem,Item>()
                     .RegisterType<IOrdered,Ordered>()
                     .RegisterType<IOrder,Order>()
                     .RegisterType<IOrderStatus,OrderStatus>()
                     .RegisterType<IRegister, Register>()
                     .RegisterType<ICardInfo,CardInfo>()
                     .RegisterType<IApplicationUser,ApplicationUser>();
        }
    }
}
