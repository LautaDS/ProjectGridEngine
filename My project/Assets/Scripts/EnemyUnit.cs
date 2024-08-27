using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Units
{
    public class EnemyUnit : BaseUnit
    {
        public Faction Faction = Faction.Enemy;
        // Start is called before the first frame update

        public new void Initialize(ScriptableUnit scriptableUnit)
        {
            // Call the base class Initialize or setup method
            base.Initialize(scriptableUnit);

            // Add any additional PlayerUnit-specific initialization here if needed
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
