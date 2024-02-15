import xml.etree.ElementTree as ET

def xml_to_dict(element):
    data = {}
    for child in element:
        if len(child) == 0:
            data[child.tag] = child.text
        else:
            data[child.tag] = xml_to_dict(child)
    return data

def deserialize_from_xml(file_path):
    tree = ET.parse(file_path)
    root = tree.getroot()
    return xml_to_dict(root)

# Example usage
if __name__ == "__main__":
    xml_file_path = "customer.xml"

    # Deserialize data from XML
    deserialized_data = deserialize_from_xml(xml_file_path)

    print("Data deserialized from XML:")
    print(deserialized_data)