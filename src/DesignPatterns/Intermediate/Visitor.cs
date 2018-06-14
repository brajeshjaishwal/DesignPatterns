/*
 * Definition: Represents an operation to be performed on the elements of an object structure.
 * Visitor lets you define a new operation without changing the classes of the elements on which it operates.
 */

namespace DesignPatterns.Intermediate
{
    using System.Text;

    public interface IVisitor
    {
        void Visit(Value v);
        void Visit(AdditionExpression v);
        void Visit(MultiplicationExpression v);
    }

    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }

    public abstract class Expression : IVisitable
    {
        public int Value;
        public virtual void Accept(IVisitor ev) { }
    }

    public class Value : Expression
    {
        public Value(int value)
        {
            Value = value;
        }

        public override void Accept(IVisitor ev)
        {
            ev.Visit(this);
        }

        // todo
    }

    public class AdditionExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public AdditionExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(IVisitor ev)
        {
            ev.Visit(this);
        }

        // todo
    }

    public class MultiplicationExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public MultiplicationExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(IVisitor ev)
        {
            ev.Visit(this);
        }

        // todo
    }

    public class ExpressionPrinter : IVisitor
    {
        private StringBuilder sb = new StringBuilder();

        public void Visit(Value value)
        {
            sb.Append(value);
        }

        public void Visit(AdditionExpression ae)
        {
            sb.Append($"({ae.LHS}+{ae.RHS})");
        }

        public void Visit(MultiplicationExpression me)
        {
            sb.Append($"({me.LHS}*{me.RHS})");
        }

        public string getReport() => sb.ToString();
    }

    public class ExpressionEvaluator : IVisitor
    {
        double _result;

        public void Visit(MultiplicationExpression v)
        {
            _result += (v.LHS.Value * v.RHS.Value);
        }

        public void Visit(AdditionExpression v)
        {
            _result += (v.LHS.Value + v.RHS.Value);
        }

        public void Visit(Value v)
        {
            _result += v.Value;
        }

        public double getResult() => _result;
    }

}
