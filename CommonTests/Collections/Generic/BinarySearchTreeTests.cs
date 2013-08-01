﻿namespace CommonTests.Collections.Generic
{
    using System;
    using Common.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BinarySearchTreeTests
    {
        #region BinarySearchTree.Insert

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Insert_IntoEmptyTree()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);

            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(0, b.Height);
            Assert.AreEqual<int>(1, b.Count);
            Assert.AreEqual<int>(0, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Insert_SecondNode_Left()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(25);

            Assert.IsNotNull(b.Root);
            Assert.IsNotNull(b.Root.Left);
            Assert.IsNull(b.Root.Right);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(25, b.Root.Left.Value);
            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(2, b.Count);
            Assert.AreEqual<int>(1, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Insert_SecondNode_Right()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(75);

            Assert.IsNotNull(b.Root);
            Assert.IsNotNull(b.Root.Right);
            Assert.IsNull(b.Root.Left);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(2, b.Count);
            Assert.AreEqual<int>(-1, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Insert_ThirdNode_FullTree()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(75);

            Assert.IsNotNull(b.Root);
            Assert.IsNotNull(b.Root.Right);
            Assert.IsNotNull(b.Root.Left);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(25, b.Root.Left.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(1, b.Height);
            Assert.AreEqual<int>(0, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Insert_ThirdNode_LeftLeft()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(13);

            Assert.IsNotNull(b.Root);

            Assert.IsNull(b.Root.Right);
            Assert.IsNotNull(b.Root.Left);

            Assert.IsNotNull(b.Root.Left.Left);
            Assert.IsNull(b.Root.Left.Right);

            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(25, b.Root.Left.Value);
            Assert.AreEqual<int>(13, b.Root.Left.Left.Value);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(2, b.Height);
            Assert.AreEqual<int>(2, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Insert_ThirdNode_LeftRight()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(32);

            Assert.IsNotNull(b.Root);

            Assert.IsNull(b.Root.Right);
            Assert.IsNotNull(b.Root.Left);

            Assert.IsNull(b.Root.Left.Left);
            Assert.IsNotNull(b.Root.Left.Right);

            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(25, b.Root.Left.Value);
            Assert.AreEqual<int>(32, b.Root.Left.Right.Value);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(2, b.Height);
            Assert.AreEqual<int>(2, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Insert_ThirdNode_RightLeft()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(63);

            Assert.IsNotNull(b.Root);

            Assert.IsNotNull(b.Root.Right);
            Assert.IsNull(b.Root.Left);

            Assert.IsNotNull(b.Root.Right.Left);
            Assert.IsNull(b.Root.Right.Right);

            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<int>(63, b.Root.Right.Left.Value);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(2, b.Height);
            Assert.AreEqual<int>(-2, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Insert_ThirdNode_RightRight()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            Assert.IsNotNull(b.Root);

            Assert.IsNotNull(b.Root.Right);
            Assert.IsNull(b.Root.Left);

            Assert.IsNull(b.Root.Right.Left);
            Assert.IsNotNull(b.Root.Right.Right);

            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<int>(100, b.Root.Right.Right.Value);
            Assert.AreEqual<int>(3, b.Count);
            Assert.AreEqual<int>(2, b.Height);
            Assert.AreEqual<int>(-2, b.Balance);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_DuplicateAtRoot()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            b.Insert(50);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_DuplicateInMiddle()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            b.Insert(75);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_DuplicateAsLeaf()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);

            b.Insert(100);
        }

        #endregion

        #region BinarySearchTree.Find

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Find_EmptyTree()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Find(50);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void Find_OnlyRoot_NotFound()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);

            b.Find(60);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void FindOrDefault_OnlyRoot_NotFound()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);

            Assert.IsNull(b.FindOrDefault(60));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Find_OnlyRoot_Found()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);

            var result = b.Find(50);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(50, result.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Find_Height_Equals_1_Found_Left()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(30);

            var result = b.Find(30);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(30, result.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Find_Height_Equals_1_Found_Right()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(70);

            var result = b.Find(70);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(70, result.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Find_Height_Equals_1_FullTree_Found_Left()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(30);
            b.Insert(70);

            var result = b.Find(30);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(30, result.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Find_Height_Equals_1_FullTree_Found_Right()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(30);
            b.Insert(70);

            var result = b.Find(70);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(70, result.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void Find_BiggerTree_NotFound()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            b.Find(200);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void FindOrDefault_BiggerTree_NotFound()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            Assert.IsNull(b.Find(200));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Find_BiggerTree_Found_Part1()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            var result = b.Find(75);

            Assert.IsNotNull(result);
            Assert.AreEqual<int>(75, result.Value);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Find_BiggerTree_Found_Part2()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            var result = b.Find(30);

            Assert.IsNotNull(result);
            Assert.AreEqual<int>(30, result.Value);
        }

        #endregion

        #region BinarySearchTree.Delete

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Delete_EmptyTree()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Delete(50);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void Delete_OnlyRoot_NotFound()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Delete(60);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Delete_OnlyRoot_Found()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Delete(50);

            Assert.IsNotNull(b);
            Assert.IsNull(b.Root);
            Assert.AreEqual<int>(0, b.Count);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(-1, b.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Delete_LeftLeaf()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(25);
            b.Delete(25);

            Assert.IsNotNull(b);
            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.IsNull(b.Root.Left);
            Assert.IsNull(b.Root.Right);
            Assert.AreEqual<int>(1, b.Count);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(0, b.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Delete_RightLeaf()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Delete(75);

            Assert.IsNotNull(b);
            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.IsNull(b.Root.Left);
            Assert.IsNull(b.Root.Right);
            Assert.AreEqual<int>(1, b.Count);
            Assert.AreEqual<int>(0, b.Balance);
            Assert.AreEqual<int>(0, b.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Delete_NodeThatOnlyHasRightChild()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(75);
            b.Insert(100);
            b.Delete(75);

            Assert.IsNotNull(b);
            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(100, b.Root.Right.Value);
            Assert.IsNull(b.Root.Left);
            Assert.AreEqual<int>(2, b.Count);
            Assert.AreEqual<int>(-1, b.Balance);
            Assert.AreEqual<int>(1, b.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Delete_NodeThatOnlyHasLeftChild()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(10);
            b.Delete(25);

            Assert.IsNotNull(b);
            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(10, b.Root.Left.Value);
            Assert.IsNull(b.Root.Right);
            Assert.AreEqual<int>(2, b.Count);
            Assert.AreEqual<int>(1, b.Balance);
            Assert.AreEqual<int>(1, b.Height);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Delete_Node_ThatHasBothChildren()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(50);
            b.Insert(25);
            b.Insert(75);

            b.Insert(20);
            b.Insert(30);

            b.Delete(25);

            Assert.IsNotNull(b);
            Assert.IsNotNull(b.Root);
            Assert.AreEqual<int>(50, b.Root.Value);
            Assert.AreEqual<int>(20, b.Root.Left.Value);
            Assert.AreEqual<int>(75, b.Root.Right.Value);
            Assert.AreEqual<int>(30, b.Root.Left.Right.Value);
            Assert.AreEqual<int>(4, b.Count);
            Assert.AreEqual<int>(1, b.Balance);
            Assert.AreEqual<int>(2, b.Height);
        }

        #endregion

        #region BinarySearchTree.Depth
        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Depth_NoRoot()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            int depth = b.Depth(10);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Depth_OnlyRoot()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Root = new BinaryNode<int>(10);

            Assert.AreEqual<int>(0, b.Depth(10));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void DepthOfRoot()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Root = new BinaryNode<int>(10);
            b.Root.Left = new BinaryNode<int>(5);

            Assert.AreEqual<int>(0, b.Depth(10));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void SimpleTree_DepthOfLeaf()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Root = new BinaryNode<int>(10);
            b.Root.Left = new BinaryNode<int>(5);

            Assert.AreEqual<int>(1, b.Depth(5));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Depth_Equals_1_Left()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(1, b.Depth(50));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Depth_Equals_1_Right()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(1, b.Depth(150));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Depth_Equals_2_LeftLeft()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(25));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Depth_Equals_2_LeftRight()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(75));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Depth_Equals_2_RightLeft()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(125));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Depth_Equals_2_RightRight()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(2, b.Depth(175));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Depth_Equals_3_LeftLeftRight()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            Assert.AreEqual<int>(3, b.Depth(30));
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(NodeNotFoundException))]
        public void Depth_NodeNotFound()
        {
            BinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Root = new BinaryNode<int>(100);
            b.Root.Left = new BinaryNode<int>(50);
            b.Root.Right = new BinaryNode<int>(150);

            b.Root.Left.Left = new BinaryNode<int>(25);
            b.Root.Left.Right = new BinaryNode<int>(75);

            b.Root.Right.Left = new BinaryNode<int>(125);
            b.Root.Right.Right = new BinaryNode<int>(175);

            b.Root.Left.Left.Right = new BinaryNode<int>(30);
            b.Root.Right.Right.Left = new BinaryNode<int>(160);

            b.Depth(60);
        }
        #endregion

        #region BinarySearchTree.Traversals
        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Inorder_EmptyTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();

            var enumerator = b.InOrderIterator.GetEnumerator();
            enumerator.MoveNext();
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Inorder_BigTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            var enumerator = b.InOrderIterator.GetEnumerator();

            enumerator.MoveNext();
            Assert.AreEqual<int>(25, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(30, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(50, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(75, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(100, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(125, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(150, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(160, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(175, enumerator.Current);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Preorder_EmptyTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();

            var enumerator = b.PreOrderIterator.GetEnumerator();
            enumerator.MoveNext();
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Preorder_BigTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            var enumerator = b.PreOrderIterator.GetEnumerator();

            enumerator.MoveNext();
            Assert.AreEqual<int>(100, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(50, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(25, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(30, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(75, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(150, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(125, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(175, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(160, enumerator.Current);
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(TreeNotRootedException))]
        public void Postorder_EmptyTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();

            var enumerator = b.PostOrderIterator.GetEnumerator();
            enumerator.MoveNext();
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Postorder_BigTree()
        {
            IBinarySearchTree<int> b = new BinarySearchTree<int>();
            b.Insert(100);

            b.Insert(50);
            b.Insert(150);

            b.Insert(25);
            b.Insert(75);
            b.Insert(125);
            b.Insert(175);

            b.Insert(30);
            b.Insert(160);

            var enumerator = b.PostOrderIterator.GetEnumerator();

            enumerator.MoveNext();
            Assert.AreEqual<int>(30, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(25, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(75, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(50, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(125, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(160, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(175, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(150, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(100, enumerator.Current);
        }
        #endregion

        #region BinarySearchTree.AssertTree

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        public void Assert_ValidTree()
        {
            BinaryNode<int> root = new BinaryNode<int>(100);
            root.Left = new BinaryNode<int>(50);
            root.Right = new BinaryNode<int>(150);

            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        [TestMethod]
        [TestCategory("BinarySearchTree")]
        [ExpectedException(typeof(InvalidTreeException))]
        public void Assert_InvalidTree()
        {
            BinaryNode<int> root = new BinaryNode<int>(100);
            root.Right = new BinaryNode<int>(50);
            root.Left = new BinaryNode<int>(150);

            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Root = root;

            bst.AssertValidTree();
        }

        #endregion

    }
}
