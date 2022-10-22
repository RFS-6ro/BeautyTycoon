using Meta.Common.Assets.Characters.Visitor_default;
using UnityEngine;

namespace BT.Meta.Common.Characters.Utils
{
    public static class UnitUtils
    {
        public static void CreateCharacter(out CUnit unit)
        {
            GameObject mainCharacter = Resources.Load<GameObject>("MainCharacter");
            unit = new CUnit() { Transform = mainCharacter.transform };
        }

        public static void SummonVisitor(out CUnit unit, out CChoiceVariant choice)
        {
            GameObject visitor = Resources.Load<GameObject>("Visitor_default");
            unit = new CUnit() { Transform = visitor.transform };
            choice = new CChoiceVariant() { ChosenData = Random.Range(0, 3) };
        }
    }
}