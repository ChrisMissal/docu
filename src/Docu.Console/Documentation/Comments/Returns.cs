using System.Collections.Generic;

namespace Docu.Documentation.Comments
{
    public class Returns : BaseComment
    {
        public Returns()
            : this(new IComment[0])
        { }

        public Returns(IEnumerable<IComment> comments)
        {
            comments.ForEach(AddChild);
        }
    }
}