using System;

private class CombatLogic
{
	private void CombatLogic()
	{
        A1 = data;
        A2 = data2;
	P1_Health = P1.getHealth();
	P2_Health = P2.gethHealth();

	if (A1 == A2)
	{
		//return tie
		returnData = "You have tied!";
	}

	if ((A1 - A2) % 3 == 1)
	{
		//A1 wins
		if (A1 == "HA")
		{
			int damage = 2;
			P2_Health = P2_Health - 2;
			returnData = "Player One dealt " + damage + " damage!";

		}

		if (A1 == "QA")
		{
			int damage = 1;
			P2_Health = P2_Health - 1;
			returnData = "Player One dealt " + damage + " damage!";
		}

		if (A1 == "BL")
		{
			int regen = 1;
			P1_Health = P1_Health + 1;
			returnData = "Player One regained " + regen + " life!";
		}
	}

	else
		//A2 wins
		if (A2 == "HA")
		{
			int damage = 2;
			P1_Health = P1_Health - 2;
			returnData = "Player Two dealt " + damage + " damage!";
		}

		if (A2 == "QA")
		{
			int damage = 1;
			P1_Health = P1_Health - 1;
			returnData = "Player Two dealt " + damage + " damage!";
		}

		if (A2 == "BL")
		{
			int regen = 1;
			P2_Health = P2_Health + 1;
			returnData = "Player One regained " + regen + " life!";
		}
	}
}

