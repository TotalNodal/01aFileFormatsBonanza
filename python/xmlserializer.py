import xml.etree.ElementTree as ET

def dict_to_xml(element, data):
    for key, value in data.items():
        if isinstance(value, dict):
            sub_element = ET.SubElement(element, key)
            dict_to_xml(sub_element, value)
        else:
            ET.SubElement(element, key).text = str(value)

def serialize_to_xml(data, root_name, file_path):
    root = ET.Element(root_name)
    dict_to_xml(root, data)

    tree = ET.ElementTree(root)
    with open(file_path, "wb") as file:
        tree.write(file)

# Example usage
if __name__ == "__main__":
    # Example data to serialize
    data_to_serialize = {
        "person": {
            "FirstName": "John",
            "LastName": "Doe",
            "Address": "123 Example St"
        }
    }

    # Specify the root element name and the path for the XML file
    root_name = "data"
    xml_file_path = "customer.xml"

    # Serialize the data to XML
    serialize_to_xml(data_to_serialize, root_name, xml_file_path)

    print(f"Data serialized to {xml_file_path}")