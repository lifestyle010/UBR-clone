using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayButtonDrawer : MonoBehaviour
{
    public static PlayButtonDrawer instance;
    public Animator drawAnimator;
    public bool drawerOpen;
    [Header("TextMeshPro Objects")]
    public TextMeshProUGUI selectedMode;
    public TextMeshProUGUI topMode;
    public TextMeshProUGUI midMode;
    public TextMeshProUGUI botMode;

    public int orderSet;
    public int selectedPosition;

    public int[] order;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        orderSet = 0;
        order = new int[] { 1, 2, 3, 4 };
    }

    public void SwitchOrderSet(int setNum)
    {
        switch(setNum)
        {
            case 0:
                //set order for solo
                order = new int[] { 1, 2, 3, 4 };
                break;
            case 1:
                order = new int[] { 2, 1, 3, 4 };
                break;
            case 2:
                order = new int[] { 3, 1, 2, 4 };
                break;
            case 3:
                order = new int[] { 4, 1, 2, 3 };
                break;
            default:
                break;
        }
    }

    public void OpenDrawer()
    {
        drawAnimator.SetBool("Close", false);
        drawAnimator.SetBool("Open", true);
    }
    public void CloseDrawer()
    {
        drawAnimator.SetBool("Open", false);
        drawAnimator.SetBool("Close", true);
    }

    public void DrawerPullClicked()
    {
        if (!drawerOpen)
        {
            OpenDrawer();
            drawerOpen = true;
        }
        else
        {
            CloseDrawer();
            drawerOpen = false;
        }
    }

    public void DrawerButtonPressed(int position)
    {
        //get the index of order for the position entered
        selectedPosition = order[position];

        SwitchOrderSet(position);

        ModeSelect(selectedPosition);

        drawerOpen = false;
    }

    public void ModeSelect(int mode)
    {
        switch (mode)
        {
            case 1:
                //change selected to
                selectedMode.text = "Solo -1 Player";
                //change top tmp to
                topMode.text = "Duos -2 Players";
                midMode.text = "Trio -3 Players";
                botMode.text = "Team -4 Players";
                //close the drawer
                CloseDrawer();
                break;
            case 2:
                //change selected to
                selectedMode.text = "Duos -2 Players";
                //change top tmp to
                topMode.text = "Solo -1 Player";
                midMode.text = "Trio -3 Players";
                botMode.text = "Team -4 Players";
                //close the drawer
                CloseDrawer();
                break;
            case 3:
                //change selected to
                selectedMode.text = "Trio -3 Players";
                //change top tmp to
                topMode.text = "Solo -1 Player";
                midMode.text = "Duos -2 Players";
                botMode.text = "Team -4 Players";
                //close the drawer
                CloseDrawer();
                break;
            case 4:
                //change selected to
                selectedMode.text = "Team -4 Players";
                //change top tmp to
                topMode.text = "Solo -1 Player";
                midMode.text = "Duos -2 Players";
                botMode.text = "Trio -3 Players";
                //close the drawer
                CloseDrawer();
                break;
            default:
                break;
        }
    }
}
