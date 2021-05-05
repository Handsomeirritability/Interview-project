using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Test
    {
        private delegate void setTxtContent(string msg);
        public Dictionary<int, List<int>> dicAll;
        public Random ran;
        public string result = string.Empty;
        public void GetAllData()
        {
            dicAll?.Clear();
            dicAll.Add(1, new List<int>() { 1, 2, 3 });
            dicAll.Add(2, new List<int>() { 4, 5, 6, 7, 8 });
            dicAll.Add(3, new List<int>() { 9, 10, 11, 12, 12, 14, 15 });
        }

        public async void GetTakePoker()
        {
            int userSelectedRow = ran.Next(1, dicAll.Count + 1);
            if (dicAll[userSelectedRow] == null || dicAll[userSelectedRow].Count == 0)
            {
                result = "数据异常";
                return;
            }
            while (dicAll[userSelectedRow].Count > 0)
            {
                userOneTake(userSelectedRow);
                userTwoTake(userSelectedRow);
            }
        }
        /// <summary>
        /// 用户一拿火柴
        /// </summary>
        /// <param name="userOneSelectedRow"></param>
        /// <returns></returns>
        private bool userOneTake(int userOneSelectedRow)
        {
            try
            {
                GetPokerCaculate(userOneSelectedRow, Operation.userOne);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 用户二拿火柴
        /// </summary>
        /// <param name="userOneSelectedRow"></param>
        /// <returns></returns>
        private bool userTwoTake(int userOneSelectedRow)
        {

            try
            {
                GetPokerCaculate(userOneSelectedRow, Operation.userTwo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 取火柴计算
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="operation"></param>
        private void GetPokerCaculate(int rowIndex, Operation operation)
        {
            List<int> lstSelectedRowData = dicAll[rowIndex];
            if (lstSelectedRowData.Count == 0)
            {
                return;
            }
            int selectCount = ran.Next(1, lstSelectedRowData.Count + 1);
            dicAll[rowIndex].RemoveRange(0, selectCount);
            if (dicAll[rowIndex].Count == 0)//最后一个取完列表中的火柴判定为输
            {
                string content = string.Empty;
                if (operation == Operation.userOne)
                {
                    content = "userOne lose";
                }
                else
                {
                    content = "userTwo lose";
                }
                result = content;
            }
        }
    }

    public enum Operation
    {
        userOne,
        userTwo
    }
}
