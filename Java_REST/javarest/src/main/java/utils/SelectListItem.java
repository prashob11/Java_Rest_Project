package utils;

import org.codehaus.jackson.annotate.JsonProperty;

public class SelectListItem {
	public SelectListItem(String text, String value) {
		super();
		this.text = text;
		this.value = value;
	}

	@JsonProperty("Text")
	private String text;
	@JsonProperty("Value")
	private String value;

	public String getText() {
		return text;
	}

	public String getValue() {
		return value;
	}

}
