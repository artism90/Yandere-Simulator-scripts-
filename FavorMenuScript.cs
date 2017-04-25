using System;
using UnityEngine;

// Token: 0x02000093 RID: 147
[Serializable]
public class FavorMenuScript : MonoBehaviour
{
	// Token: 0x06000364 RID: 868 RVA: 0x00046CE0 File Offset: 0x00044EE0
	public FavorMenuScript()
	{
		this.ID = 1;
	}

	// Token: 0x06000365 RID: 869 RVA: 0x00046CF0 File Offset: 0x00044EF0
	public virtual void Update()
	{
		if (this.InputManager.TappedRight)
		{
			this.ID++;
			this.UpdateHighlight();
		}
		else if (this.InputManager.TappedLeft)
		{
			this.ID--;
			this.UpdateHighlight();
		}
		if (Input.GetButtonDown("A"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			if (this.ID == 1)
			{
				this.SchemesMenu.UpdatePantyCount();
				this.SchemesMenu.UpdateSchemeList();
				this.SchemesMenu.UpdateSchemeInfo();
				this.SchemesMenu.gameObject.active = true;
				this.active = false;
			}
			else if (this.ID == 2)
			{
				this.ServicesMenu.UpdatePantyCount();
				this.ServicesMenu.UpdateList();
				this.ServicesMenu.UpdateDesc();
				this.ServicesMenu.gameObject.active = true;
				this.active = false;
			}
			else if (this.ID == 3)
			{
				this.DropsMenu.UpdatePantyCount();
				this.DropsMenu.UpdateList();
				this.DropsMenu.UpdateDesc();
				this.DropsMenu.gameObject.active = true;
				this.active = false;
			}
		}
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.MainMenu.active = true;
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			this.active = false;
		}
	}

	// Token: 0x06000366 RID: 870 RVA: 0x00046F2C File Offset: 0x0004512C
	public virtual void UpdateHighlight()
	{
		if (this.ID > 3)
		{
			this.ID = 1;
		}
		else if (this.ID < 1)
		{
			this.ID = 3;
		}
		int num = -500 + 250 * this.ID;
		Vector3 localPosition = this.Highlight.transform.localPosition;
		float num2 = localPosition.x = (float)num;
		Vector3 vector = this.Highlight.transform.localPosition = localPosition;
	}

	// Token: 0x06000367 RID: 871 RVA: 0x00046FB0 File Offset: 0x000451B0
	public virtual void Main()
	{
	}

	// Token: 0x04000885 RID: 2181
	public InputManagerScript InputManager;

	// Token: 0x04000886 RID: 2182
	public PauseScreenScript PauseScreen;

	// Token: 0x04000887 RID: 2183
	public ServicesScript ServicesMenu;

	// Token: 0x04000888 RID: 2184
	public SchemesScript SchemesMenu;

	// Token: 0x04000889 RID: 2185
	public DropsScript DropsMenu;

	// Token: 0x0400088A RID: 2186
	public PromptBarScript PromptBar;

	// Token: 0x0400088B RID: 2187
	public Transform Highlight;

	// Token: 0x0400088C RID: 2188
	public int ID;
}
