SELECT * from tblTemplateGroup a 
                        inner join relTemplateGroupTemplate b on b.nTemplateGroupID = a.nTemplateGroupID 
                        inner join tblTemplate c on c.nTemplateID = b.nTemplateID 
                        inner join relTemplateButtonAttribute d on d.nTemplateID = c.nTemplateID
                        inner join tblButtonAttribute e on e.nRecID = d.nButtonRecID 
                        order by a.nOrder asc, c.nOrder asc, e.nRecID asc-- limit 1
                        
                        
                        
                        strTemplateGroupName = result.GetString(1);
                        nOrder = result.GetInt16(2);
                        strTemplateName = result.GetString(7);
                        strNotes = result.GetString(8);
                        nNotesHeight = result.GetInt16(9);
                        nOrder1 = result.GetInt16(10);
                        strHotKeyLabel = result.GetString(16);
                        strHotKeyDesc = result.GetString(17);
                        nDescHeight = result.GetInt16(18);
                        nColorR = result.GetInt16(19);
                        nColorG = result.GetInt16(20);
                        nColorB = result.GetInt16(21);