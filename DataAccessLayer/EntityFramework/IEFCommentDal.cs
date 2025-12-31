using EntityLayer.Concreate;

namespace DataAccessLayer.EntityFramework
{
    public interface IEFCommentDal
    {
        List<Comment> GetCommentsbyDestinationID(int id);
        List<Comment> GetCommentsForAdminPage();
    }
}