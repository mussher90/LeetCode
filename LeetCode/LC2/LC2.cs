
namespace LeetCode
{
    public class ListNode
    {
     public int val;
     public ListNode next;
     public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
                 }
  }
    public static class LC2
    {

        public static ListNode Add(ListNode node1, ListNode node2)
        {
            return AddTwoLinkedNodes(node1, node2, 0);
        }
        private static ListNode AddTwoLinkedNodes(ListNode node1, ListNode node2, int prevOverflow)
        {
            var value = (node1.val + node2.val + prevOverflow) % 10;
            var overflow = (node1.val + node2.val + prevOverflow) / 10;

            if (node1.next is null && node2.next is null)
            {
                if(overflow > 0)
                {
                    return new ListNode { val = value, next = new ListNode { val = overflow, next = null } };

                }
                else
                {
                    return new ListNode { val = value};
                }
            }
            else if(node2.next is null)
            {
                node2.next = new ListNode { val = 0, next = null };
            }
            else if(node1.next is null)
            {
                node1.next = new ListNode { val = 0, next = null };
            }
            
            return new ListNode { val = value, next = AddTwoLinkedNodes(node1.next, node2.next, overflow) };
        }
    }
}
