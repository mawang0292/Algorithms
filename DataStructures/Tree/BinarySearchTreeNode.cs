namespace DataStructures.Trees
{
    /// <summary>
    /// 이진 검색 트리 노드.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BSTNode<T> : System.IComparable<BSTNode<T>> where T : System.IComparable<T>
    {
        private T _value;
        private BSTNode<T> _parent;
        private BSTNode<T> _left;
        private BSTNode<T> _right;

        public BSTNode() : this(default(T), 0, null, null, null) { }
        public BSTNode(T value) : this(value, 0, null, null, null) { }
        public BSTNode(T value, int subTreeSize, BSTNode<T> parent, BSTNode<T> left, BSTNode<T> right)
        {
            Value = value;
        }
        //* 값
        public virtual T Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        //* 부모 노드
        public virtual BSTNode<T> Parent
        {
            get { return this._parent; }
            set {this._parent = value; }
        }

        //* 부모기준 왼쪽 자식 노드
        public virtual BSTNode<T> LeftChild
        {
            get { return this._left; }
            set { this._left = value; }
        }

        //* 부모기준 오른쪽 자식 노드
        public virtual BSTNode<T> RightChild
        {
            get { return this._right; }
            set { this._right = value; }
        }
        
        /// <summary>
        /// * 이노드에 자식이 있는지 확인합니다.
        /// </summary>
        public virtual bool HasChildren
        {
            get { return (this.ChildrenCount > 0); }
        }

        /// <summary>
        /// * 이 노드에 자식이 남아 있는지 확인합니다.
        /// </summary>
        public virtual bool HasLeftChild
        {
            get { return (this.LeftChild != null); }
        }
        /// <summary>
        /// * 이 노드에 자식만 있고 올바른 자식인지 확인합니다.
        /// </summary>
        public virtual bool HasOnlyRightChild => !this.HasLeftChild && this.HasRightChild;

        /// <summary>
        /// * 이 노드에 올바른 자식이 있는지 확인합니다.
        /// </summary>
        public virtual bool HasRightChild
        {
            get { return (this.RightChild != null); }
        }

        /// <summary>
        /// * 이 노드에 자식이 하나만 있는지와 왼쪽 자식인지 확인합니다.
        /// </summary>
        public virtual bool HasOnlyLeftChild => !this.HasRightChild && this.HasLeftChild;

        /// <summary>
        /// * 이 노드가 부모의 왼쪽 자식인지 확인합니다.
        /// </summary>
        public virtual bool IsLeftChild
        {
            get { return (this.Parent != null && this.Parent.LeftChild == this); }
        }

        /// <summary>
        /// * 이 노드가 부모의 오른쪽 자식인지 확인합니다.
        /// </summary>
        public virtual bool IsRightChild
        {
            get { return (this.Parent != null && this.Parent.RightChild == this); }
        }

        /// <summary>
        /// * 이 노드가 리프 노드인지 확인합니다.
        /// </summary>
        public virtual bool IsLeafNode
        {
            get { return (this.ChildrenCount == 0); }
        }

        /// <summary>
        /// * 자식의 수를 반환합니다 : 0, 1, 2 (없음 ,왼쪽 또는 오른쪽, 둘다)
        /// </summary>
        public virtual int ChildrenCount
        {
            get
            {
                int count = 0;
                
                if(this.HasLeftChild)
                {
                    count++;
                }
                if(this.HasRightChild)
                {
                    count++;
                }
                return count;
            }
        }

        /// <summary>
        /// * other.Value 와 현제 노드의 Value를 비교합니다.
        /// </summary>
        public virtual int CompareTo(BSTNode<T> other)
        {
            if(other == null)
            {
                return -1;
            }

            return this.Value.CompareTo(other.Value);
        }
    }
}