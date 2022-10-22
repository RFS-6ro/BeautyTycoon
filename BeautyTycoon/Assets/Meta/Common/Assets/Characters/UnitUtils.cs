using Meta.Common.Assets.Characters.MainCharacter;
using Meta.Common.Assets.Characters.Visitor_default;
using Meta.Common.InputHandling;
using UnityEngine;

namespace BT.Meta.Common.Characters.Utils
{
    public static class UnitUtils
    {
        public static void CreateCharacter(out CUnit unit)
        {
            GameObject mainCharacter = Resources.Load<GameObject>("MainCharacter");
            unit = new CUnit() { Transform = mainCharacter.transform };
            CKeyboardInputData inputData = new CKeyboardInputData();
            CTouchInputListener listener = new CTouchInputListener();
        }

        public static void SummonVisitor(out CUnit unit, out CChoiceVariant choice)
        {
            GameObject visitor = Resources.Load<GameObject>("Visitor_default");
            unit = new CUnit() { Transform = visitor.transform };
            choice = new CChoiceVariant() { ChosenData = Random.Range(0, 3) };
        }
    }
}