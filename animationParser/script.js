let http = new XMLHttpRequest()

let url = 'convertcsv.json'

http.open('get', url)
http.onreadystatechange = e => {
  if (http.status === 200 && http.readyState === 4) {
    let data = JSON.parse(http.responseText)
    window.data = data
    let bones = data.AnimationClip.m_EulerCurves
    bones.forEach(bone => {
      console.log(bone.path)
      let values = bone.curve.m_Curve

      values.forEach(value => {
        console.log(value.value.z)
      })
    })
  }
}

http.send()
