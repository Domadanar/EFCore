using System.Collections.Generic;

namespace todo_rest_api.Dto
{
    public class DashboardDto
    {
        public int Count {get; set;} 

        public  List<DashboardTodoListDto> TodoLists { get; set; }
    }
}