using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanLi.IDAL;

namespace FanLi.DAL
{
   public static class RepositoryFactory
    {
        /// <summary>
        /// 用户仓储
        /// </summary>
        public static IAdminRepository AdminDAL { get { return new AdminDAL(); } }

        public static IAdListRepository AdListDAL { get { return new AdListDAL(); } }
        public static IAdPositionRepository AdPositionDAL { get { return new AdPositionDAL(); } }

        public static IAdminRoleRepository AdminRoleDAL { get { return new AdminRoleDAL(); } }
        public static IAdminFunctionRepository AdminFunctionDAL { get { return new AdminFunctionDAL(); } }

        public static IFavoriteRepository FavoriteDAL { get { return new FavoriteDAL(); } }

        public static IHelpRepository HelpDAL { get { return new HelpDAL(); } }

        public static IHelpTypeRepository HelpTypeDAL { get { return new HelpTypeDAL(); } }

        public static ILogisticalRepository LogisticalDAL { get { return new LogisticalDAL(); } }

        public static IMallsRepository MallsDAL { get { return new MallsDAL(); } }

        public static IMallTypeRepository MallTypeDAL { get { return new MallTypeDAL(); } }

        public static INewsRepository NewsDAL { get { return new NewsDAL(); } }

        public static IPackageRepository PackageDAL { get { return new PackageDAL(); } }

        public static IProductsRepository ProductsDAL { get { return new ProductsDAL(); } }

        public static IProductTypeRepository ProductTypeDAL { get { return new ProductTypeDAL(); } }

        public static IUserRepository UserDAL { get { return new UserDAL(); } }

        public static IVideoCommentRepository VideoCommentDAL { get { return new VideoCommentDAL(); } }

        public static IVideoRepository VideoDAL { get { return new VideoDAL(); } }

        public static IVideoZanRepository VideoZanDAL { get { return new VideoZanDAL(); } }
        public static ICitysRepository CitysDAL { get { return new CitysDAL(); } }
    }
}
