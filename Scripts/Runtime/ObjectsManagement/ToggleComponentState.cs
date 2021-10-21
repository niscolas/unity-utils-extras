﻿using UnityAtoms;
using UnityEngine;

namespace niscolas.UnityUtils.UnityAtoms
{
	[CreateAssetMenu(
		menuName = UnityAtomsConstants.ActionsCreateAssetMenuPrefix + "(Behaviour) => Toggle Enabled State")]
	public class ToggleComponentState : AtomAction<Behaviour>
	{
		public override void Do(Behaviour entry)
		{
			if (!entry)
			{
				return;
			}

			entry.enabled = !entry.enabled;
		}
	}
}