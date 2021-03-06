// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("TextMesh Pro Shader")]
	[Tooltip("Set Text Mesh Pro bevel shaders.")]

	public class  setTextmeshProShaderPropertiesBevel : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(TextMeshPro))]
		[Tooltip("Textmesh Pro component is required.")]
		public FsmOwnerDefault gameObject;

        [TitleAttribute("Enable Bevel")]
        public FsmBool enable;

        [HasFloatSlider(0, 1)]
        public FsmFloat amount;

        [HasFloatSlider(-0.5f, 0.5f)]
        public FsmFloat offset;

        [HasFloatSlider(-0.5f, 0.5f)]
        public FsmFloat width;

        [HasFloatSlider(0, 1)]
        public FsmFloat roundness;

        [HasFloatSlider(0, 1)]
        public FsmFloat clamp;

        [TitleAttribute("Enable for Inner Bevel")]
        public FsmBool innerBevel;

        [Tooltip("Check this box to preform this action every frame.")]
		public FsmBool everyFrame;

		TextMeshPro meshproScript;

		public override void Reset()
		{

            amount = null;
            innerBevel = null;
            offset = null;
            width = null;
            roundness = null;
            clamp = null;
            gameObject = null;
            everyFrame = false;
            enable = false;
		}

		public override void OnEnter()
		{

           var go = Fsm.GetOwnerDefaultTarget(gameObject);
           meshproScript = go.GetComponent<TextMeshPro>();

			if (!everyFrame.Value)
			{
				DoMeshChange();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoMeshChange();
			}
		}

		void DoMeshChange()
		{

    var go = Fsm.GetOwnerDefaultTarget(gameObject);

            if (go == null)
			{
				return;
			}

            if (enable.Value == true)
            {
                meshproScript.fontSharedMaterial.EnableKeyword("BEVEL_ON");
            }

            if (innerBevel.Value == true)
            {
                meshproScript.fontSharedMaterial.SetFloat("_ShaderFlags", 1);
            }
            else if (innerBevel.Value == false)
            {
                meshproScript.fontSharedMaterial.SetFloat("_ShaderFlags", 0);
            }

            meshproScript.fontSharedMaterial.SetFloat("_Bevel", amount.Value);
            meshproScript.fontSharedMaterial.SetFloat("_BevelOffset", offset.Value);
            meshproScript.fontSharedMaterial.SetFloat("_BevelWidth", width.Value);
            meshproScript.fontSharedMaterial.SetFloat("_BevelClamp", clamp.Value);
            meshproScript.fontSharedMaterial.SetFloat("_BevelRoundness", roundness.Value);








        }

    }
}