import React from 'react'
import PropTypes from 'prop-types'

function Hello(props) {
  return (
    <div>
      hello {props.name}
    </div>
  )
}

Hello.propTypes = {
  name: PropTypes.string
}

export default Hello

