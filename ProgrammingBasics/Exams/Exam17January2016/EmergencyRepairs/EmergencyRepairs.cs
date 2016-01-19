namespace EmergencyRepairs
{
    using System;

    class EmergencyRepairs
    {
        static void Main()
        {
            ulong fenceCondition = ulong.Parse(Console.ReadLine());
            int numberOfEmergencyKits = int.Parse(Console.ReadLine());
            int numberOfAttacks = int.Parse(Console.ReadLine());
            string fence = Convert.ToString((long)fenceCondition, 2).PadLeft(64, '0');

            for (int i = 0; i < numberOfAttacks; i++)
            {
                int attackPosition = int.Parse(Console.ReadLine());
                
                if (fence[fence.Length - attackPosition - 1] == '1')
                {
                    fence = fence
                        .Remove(fence.Length - attackPosition - 1, 1)
                        .Insert(fence.Length - attackPosition - 1, "0");
                }
            }

            for (int i = fence.Length - 1; i > 0; i--)
            {
                if (fence[i] == '0' && fence[i - 1] == fence[i])
                {
                    for (int j = i; j >= 0; j--)
                    {
                        if (fence[j] == '0' && numberOfEmergencyKits > 0)
                        {
                            fence = fence
                                .Remove(j, 1)
                                .Insert(j, "1");
                            numberOfEmergencyKits--;
                        }
                        else
                        {
                            break;
                        }
                    }                    
                }

                if (numberOfEmergencyKits <= 0)
                {
                    break;
                }
            }

            Console.WriteLine(Convert.ToUInt64(fence, 2));
        }
    }
}
