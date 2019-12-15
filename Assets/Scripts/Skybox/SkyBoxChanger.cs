using UnityEngine;
using UnityEngine.UI;

public class SkyBoxChanger : MonoBehaviour
{
  public Material[] Skyboxes;
  private Dropdown _dropdown;

  public void Start()
  {
    _dropdown = GetComponent<Dropdown>();
    ChangeSkybox();
    //var options = Skyboxes.Select(skybox => skybox.name).ToList();
    //_dropdown.AddOptions(options);
  }

  public void ChangeSkybox()
  {
    RenderSettings.skybox = Skyboxes[0];
    RenderSettings.skybox.SetFloat("_Rotation", 0);
  }
}