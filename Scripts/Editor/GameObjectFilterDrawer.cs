using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(GameObjectFilter))]
public class GameObjectFilterDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);
		Rect rComparison = EditorGUI.PrefixLabel(position, label);
		rComparison.height = EditorGUIUtility.singleLineHeight;

		SerializedProperty comparisonProperty = property.FindPropertyRelative("m_FilterBy");
		EditorGUI.PropertyField(rComparison, comparisonProperty);

		Rect rCompareValue = rComparison;
		rCompareValue.y += EditorGUIUtility.singleLineHeight;
		rCompareValue.height = EditorGUIUtility.singleLineHeight;
		EditorGUI.PropertyField(rCompareValue, comparisonProperty.enumValueIndex == 0 ? property.FindPropertyRelative("m_LayerMask") : property.FindPropertyRelative("m_Tag"));
		EditorGUI.EndProperty();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return EditorGUIUtility.singleLineHeight * 2;
	}
}
