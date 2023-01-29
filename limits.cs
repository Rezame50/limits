using Terraria;
using Terraria.ModLoader;
using static limits.limits_ModCustomCFGServer;
//
using MonoMod.Cil;
using static Mono.Cecil.Cil.OpCodes;
using System.Diagnostics;

namespace limits
{
	public class limits : ModSystem
	{
        public override void OnModLoad()
        {
            DoIL();
        }
        public override void OnWorldLoad()
        {
            if (CFG_S.UpdateOnWorldLoad)
            {
                UndoIL();
                DoIL();
            }
        }
        private void DoIL()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            IL.Terraria.Projectile.NewProjectile_IEntitySource_float_float_float_float_int_int_float_int_float_float += Projectile_NewProjectile_IEntitySource_float_float_float_float_int_int_float_int_float_float;
            IL.Terraria.Projectile.FindOldestProjectile += Projectile_FindOldestProjectile;
            IL.Terraria.NPC.NewNPC += NewNPC;

            stopwatch.Stop();
            Mod.Logger.Info($"ILEditing done in {stopwatch.ElapsedMilliseconds} ms.");
        }
        private void UndoIL()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            IL.Terraria.Projectile.NewProjectile_IEntitySource_float_float_float_float_int_int_float_int_float_float -= Projectile_NewProjectile_IEntitySource_float_float_float_float_int_int_float_int_float_float;
            IL.Terraria.Projectile.FindOldestProjectile -= Projectile_FindOldestProjectile;
            IL.Terraria.NPC.NewNPC -= NewNPC;

            stopwatch.Stop();
            Mod.Logger.Info($"ILEditing undone in {stopwatch.ElapsedMilliseconds} ms.");
        }

        private void Projectile_NewProjectile_IEntitySource_float_float_float_float_int_int_float_int_float_float(MonoMod.Cil.ILContext il)
        {
            var curs = new ILCursor(il);

            if (0 == CFG_S.MaxProjectiles)
            {
                curs.Emit(Ldloc_0);
                curs.Emit(Ret);
                return;
            }

            while (curs.TryGotoNext(i => i.OpCode == Ldc_I4 &&
                               i.Operand.ToString() == "1000"))
            {
                curs.Next.Operand = CFG_S.MaxProjectiles;
            }
        }
        private void Projectile_FindOldestProjectile(ILContext il)
        {
            var curs = new ILCursor(il);

            while (curs.TryGotoNext(i => i.OpCode == Ldc_I4 &&
                               i.Operand.ToString() == "1000"))
            {
                curs.Next.Operand = CFG_S.MaxProjectiles;
            }
        }

        private void NewNPC(ILContext il)
        {
            var curs = new ILCursor(il);

            curs.GotoNext(i => i.OpCode == Ldc_I4 &&
                               i.Operand.ToString() == "200");

            curs.Next.Operand = CFG_S.MaxNPCs;
        }
    }
}