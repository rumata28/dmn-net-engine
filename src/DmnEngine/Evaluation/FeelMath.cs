using System;

namespace Softengi.DmnEngine.Evaluation
{
	static public class FeelMath
	{
		static public EvaluationValue Power(EvaluationValue powBase, EvaluationValue powExp)
		{
			if (powBase.IsNull || powExp.IsNull)
				return EvaluationValue.Null;
			if (!powBase.IsNumber)
				throw new EvaluationException("Exponentiation operation base is not a number.");
			if (!powExp.IsNumber)
				throw new EvaluationException("Exponent is not a number.");

			try
			{
				var baseAsDouble = (double) (decimal) powBase;
				var powExpAsDouble = (double) (decimal) powExp;
				var resultAsDouble = Math.Pow(baseAsDouble, powExpAsDouble);
				return DoubleToEvaluationResult(resultAsDouble);
			}
			catch
			{
				return EvaluationValue.Null;
			}
		}

		static public EvaluationValue Add(EvaluationValue addend1, EvaluationValue addend2)
		{
			if (addend1.IsNull || addend2.IsNull)
				return EvaluationValue.Null;
			if (!addend1.IsNumber)
				throw new EvaluationException("Addition operation error: addend1 is not a number.");
			if (!addend2.IsNumber)
				throw new EvaluationException("Addition operation error: addend2 is not a number.");

			try
			{
				return addend1 + (decimal) addend2;
			}
			catch
			{
				return EvaluationValue.Null;
			}
		}

		static public EvaluationValue Sub(EvaluationValue subtrahend, EvaluationValue minuend)
		{
			if (subtrahend.IsNull || minuend.IsNull)
				return EvaluationValue.Null;
			if (!subtrahend.IsNumber)
				throw new EvaluationException("Subtration operation error: subtrahend is not a number.");
			if (!minuend.IsNumber)
				throw new EvaluationException("Subtration operation error: minuend is not a number.");

			try
			{
				return subtrahend - minuend;
			}
			catch
			{
				return EvaluationValue.Null;
			}
		}

		static public EvaluationValue Mul(EvaluationValue multiplicand, EvaluationValue multiplier)
		{
			if (multiplicand.IsNull || multiplier.IsNull)
				return EvaluationValue.Null;
			if (!multiplicand.IsNumber)
				throw new EvaluationException("Multiplication operation error: multiplicand is not a number.");
			if (!multiplier.IsNumber)
				throw new EvaluationException("Multiplication operation error: multiplier is not a number.");

			try
			{
				return multiplicand*multiplier;
			}
			catch
			{
				return EvaluationValue.Null;
			}
		}

		static public EvaluationValue Div(EvaluationValue dividend, EvaluationValue divisor)
		{
			if (dividend.IsNull || divisor.IsNull)
				return EvaluationValue.Null;
			if (!dividend.IsNumber)
				throw new EvaluationException("Division operation error: dividend is not a number.");
			if (!divisor.IsNumber)
				throw new EvaluationException("Division operation error: divisor is not a number.");

			try
			{
				return dividend/divisor;
			}
			catch
			{
				return EvaluationValue.Null;
			}
		}

		static private EvaluationValue DoubleToEvaluationResult(double result)
		{
			if (double.IsInfinity(result) || double.IsNaN(result))
				return EvaluationValue.Null;

			try
			{
				return (decimal) result;
			}
			catch (OverflowException)
			{
				return EvaluationValue.Null;
			}
		}
	}
}