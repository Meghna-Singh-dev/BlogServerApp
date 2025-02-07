﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
	public class BlogPost
	{
		[Key]
		public int PostId { get; set; }
		[Required]
		public string Creator { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string Body { get; set; }
		[Required]
		public DateTime Dt { get; set; }
	}

    public class BlogPostData
    {
        List<BlogPost> abc = new List<BlogPost>{
                new BlogPost { PostId = 113, Title = "kkk", Body = "weqrqwewe"},
                new BlogPost { PostId =111,Title="jjj", Body = "asdsdasderyretrg"},
                new BlogPost { PostId = 112, Title = "nnn" , Body = "t54rthgfetryth"},
            };


    }
}
